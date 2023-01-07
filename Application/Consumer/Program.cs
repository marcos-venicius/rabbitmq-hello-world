using Commons;
using Consumer;

using var subscriber = new Subscriber(Queues.HelloWorld);

subscriber.OnReceived += data =>
{
    Console.WriteLine($"@{data.Username} sent: {data.Message}");
};

subscriber.Listen();

Console.WriteLine("press [enter] to quit");
Console.ReadKey();