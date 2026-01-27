using System.Globalization;

public class Program
{
    static bool isPrime(int num)
    {
        if(num <= 1) return false;
        if(num == 2) return true;
        if(num % 2 == 0) return false;

        for(int i= 3; i*i<= num ; i+= 2)
        {
            if(num % i==0) return false;
        }
        return true;
    }

    static int SumOfDigits(int num)
    {
        int sum =0;
        while(num >0)
        {
            sum += num%10;
            num /= 10;
        }
        return sum;
    }
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter two numbers separated by spaces");
        string[] input = Console.ReadLine().Split();
        
        int m = int.Parse(input[0]);
        int n = int.Parse(input[1]);

        int count =0;
        for(int x = m; x<=n; x++)
        {
            if (!isPrime(x))
            {
                int sx = SumOfDigits(x);
                int sxsq = SumOfDigits(x*x);
                if(sxsq == sx * sx)
                {
                    count++;
                }
            }
        }
        Console.WriteLine(count);
    }
}