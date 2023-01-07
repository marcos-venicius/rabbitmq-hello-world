using Commons;
using RabbitMQ.Client;

namespace Producer;

public class Sender : IDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    
    private readonly string _queueName;
    
    public Sender(string queueName)
    {
        _queueName = queueName;

        var factory = new ConnectionFactory
        {
            UserName = "user",
            Password = "password",
            HostName = "localhost"
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    public void Send(Data data)
    {
        // create queue if not exists
        _channel.QueueDeclare(
            queue: _queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        var body = DataEncoder.Encode(data);
        
        // publish data
        _channel.BasicPublish(
            exchange: "",
            routingKey: _queueName,
            basicProperties: null,
            body: body
        );
    }
    
    public void Dispose()
    {
        _connection.Dispose();
        _channel.Dispose();
    }
}