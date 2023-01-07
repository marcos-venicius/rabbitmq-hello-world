namespace Commons;

public sealed class ReadFromCommandLine
{
    public required string EmptyErrorMessage;
    public required string InputDisplayMessage;
    
    public string Read()
    {
        while (true)
        {
            Console.Write($"\n{InputDisplayMessage}");
            
            var input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                return input;
            
            Console.Clear();
            Console.WriteLine($"\n{EmptyErrorMessage}");
        }
    }
}