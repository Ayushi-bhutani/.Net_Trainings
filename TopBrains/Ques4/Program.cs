
namespace student{
public class Program
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter length of string array");
        int n = int.Parse(Console.ReadLine());
        string[] items = new string[n];

        Console.WriteLine("Enter items to be stored (name:score)");
        for(int i=0; i<n; i++)
        {
            items[i] = Console.ReadLine();
        }

        Console.WriteLine("Enter minimum score");

        int minScore = int.Parse(Console.ReadLine());

        string result = Records.BuildResult(items, minScore);
        Console.WriteLine(result);
    }
}
}