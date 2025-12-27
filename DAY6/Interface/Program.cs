//defining interface which needs to be implemented before use 
public interface Interfaces
{
    public void DisplayMessage(string message);
    
}

// defining class program ineriting Interface class so that we can use its methods without overriding
public class Program : Interfaces
{
    
    //entry point 
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter your name");
        string? name = Console.ReadLine();
        Program p = new Program();
        p.DisplayMessage(name);
    }
    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
    
}
