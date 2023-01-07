namespace Commons;

public sealed class ReadFromCommandLine
{
    public required string EmptyErrorMessage;
    public required string InputDisplayMessage;
    
    public string Read()
    {
        Console.Clear();
        
        while (true)
        {
            Console.Write("\n{0}", InputDisplayMessage);
            
            var input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                return input;
            
            Console.Clear();
            Console.WriteLine("\n{0}", EmptyErrorMessage);
        }
    }
}