public class Program
{
    public static void Main(String[] args)
    {
        int a = 10, b = 20;
        SwapRef(ref a, ref b);
        Console.WriteLine($"After ref swap: a = {a}, b= {b}");
        SwapOut(a,b,out a, out b);
        Console.WriteLine($"After swap out : a = {a}, b= {b}");



    }
    public static void SwapRef(ref int x, ref int y)
    {
        x = x+y;
        y = x-y;
        x = x-y;

    }
    public static void SwapOut(int x, int y, out int a, out int b)
    {
        x = x+y;
        y = x-y;
        x = x-y;
        a = x;
        b = y;
    }
}
