using Commons;
using Producer;

var getUserName = new ReadFromCommandLine
{
    EmptyErrorMessage = "please, enter you username",
    InputDisplayMessage = "username: "
};

var username = getUserName.Read();

using var sender = new Sender("hello-world");

while (true)
{
    Console.Clear();
    
    var getMessage = new ReadFromCommandLine
    {
        EmptyErrorMessage = "please, enter your message",
        InputDisplayMessage = "message: "
    };

    var message = getMessage.Read();

    Console.WriteLine("\n- SENDING by [{0}]: {1}", username, message);

    var data = new Data(username, message);
    
    sender.Send(data);

    Console.WriteLine("\n- Message sent. press [enter] to continue...\n");
    Console.ReadKey();
}
