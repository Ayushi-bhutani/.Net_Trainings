using System;
public class Prac9{
    static (int, int) Input(){
        Console.WriteLine("Enter x coordinate:");
        int.TryParse(Console.ReadLine(), out int x);
        Console.WriteLine("Enter y coordinate:");
        int.TryParse(Console.ReadLine(), out int y);
        return (x,y);

    }
    static void Quadrant(int x, int y){
        if(x > 0 && y > 0) Console.WriteLine(1);
        else if (x<0 && y >0) Console.WriteLine(2);
        else if ( x > 0 && y<0) Console.WriteLine(4);
        else Console.WriteLine(3);
    }
    public static void Main9(String[] args){
        var(x,y) = Input();
        Quadrant(x,y);
    }
}