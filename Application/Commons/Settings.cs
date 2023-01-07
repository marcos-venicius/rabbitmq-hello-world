namespace Commons;

public static class Settings
{
    public static readonly string RabbitMqUsername = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "user";
    public static readonly string RabbitMqPassword = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "password";
    public static readonly string RabbitMqHostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST_NAME") ?? "localhost";
    public static readonly string RabbitMqPort = Environment.GetEnvironmentVariable("RABBITMQ_PORT") ?? "5672";
}