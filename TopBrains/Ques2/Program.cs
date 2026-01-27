using System.Data;

public class Program
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter two numbers first : n(int) , second : upto (int)");
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        List <int> result = GetTable(n,m);
        Console.WriteLine(string.Join(" ", result));
        
       
    }
    static List<int> GetTable(int n, int m)
    {
        List<int> ans = new List<int>();

        for(int i=1; i<= m ; i++)
        {
            ans.Add(n*i);
        }
        return ans;
    }
}