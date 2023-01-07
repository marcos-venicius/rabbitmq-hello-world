using Commons;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer;

public sealed class Subscriber : IDisposable
{
    private readonly string _queueName;
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public Subscriber(string queueName)
    {
        _queueName = queueName;

        var factory = new ConnectionFactory
        {
            UserName = Settings.RabbitMqUsername,
            Password = Settings.RabbitMqPassword,
            HostName = Settings.RabbitMqHostName,
            Port = int.Parse(Settings.RabbitMqPort)
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    public delegate void ReceiveEventHandler(Data data);

    public event ReceiveEventHandler? OnReceived;

    public void Listen()
    {
        _channel.QueueDeclare(
            queue: _queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += (_, eventArgs) =>
        {
            var bytes = eventArgs.Body.ToArray();
            
            var decodedData = DataEncoder.Decode(bytes);
            
            OnReceived?.Invoke(decodedData);
        };
        
        _channel.BasicConsume(
            queue: _queueName,
            autoAck: true,
            consumer: consumer
        );
    }

    public void Dispose()
    {
        _connection.Dispose();
        _channel.Dispose();
    }
}