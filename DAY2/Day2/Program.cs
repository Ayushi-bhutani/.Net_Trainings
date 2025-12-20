using System;
public class Calc
{
    int a,b;
    /// <summary>
    /// this is for calculation
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public Calc(int x, int y)
    {
        a=x;
        b=y;
    }
    public int Add()
    {
        return a+b;
    }
    public int Subtract()
    {
        if(a>b) return a-b;
        else return b-a;
    }
    public static void Main1(String[] args)
    {
        Calc c = new Calc(10,5);
        Console.WriteLine("Addition:"+c.Add());
        Console.WriteLine("Subtraction:"+c.Subtract());


    }

}
