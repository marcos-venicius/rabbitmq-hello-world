using Commons;
using Producer;

var getUserName = new ReadFromCommandLine
{
    EmptyErrorMessage = "please, enter your username",
    InputDisplayMessage = @"==== WELCOME ====

please, enter an username.

username: "
};

Console.Clear();

var username = getUserName.Read();

using var publisher = new Publisher(Queues.HelloWorld);

while (true)
{
    Console.Clear();
    
    var getMessage = new ReadFromCommandLine
    {
        EmptyErrorMessage = "please, enter your message",
        InputDisplayMessage = @$"==== PUBLISH A MESSAGE ====

@{username}: "
    };

    var message = getMessage.Read();

    Console.WriteLine($"\n- SENDING by [{username}]: {message}");

    var data = new Data(username, message);
    
    publisher.Publish(data);

    Console.WriteLine("\n- Message sent. press [enter] to continue...\n");
    Console.ReadKey();
}
