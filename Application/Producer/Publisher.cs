using Commons;
using RabbitMQ.Client;

namespace Producer;

public sealed class Publisher : IDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    
    private readonly string _queueName;
    
    public Publisher(string queueName)
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

    public void Publish(Data data)
    {
        _channel.ExchangeDeclare(
            Exchanges.Messages,
            type: "direct",
            durable: true,
            autoDelete: false,
            arguments: null
        );
        
        _channel.QueueDeclare(
            queue: _queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );
        
        var body = DataEncoder.Encode(data);
        
        _channel.BasicPublish(
            exchange: Exchanges.Messages,
            routingKey: RoutingKeys.Logs,
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