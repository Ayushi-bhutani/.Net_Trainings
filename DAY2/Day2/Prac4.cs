using System;
public class Prac4{
    
    public static void Quad(String[] args){

        //Taking three Inputs
        Console.WriteLine("Enter first number");
        double.TryParse(Console.ReadLine(),out double a);
        Console.WriteLine("Enter second number");
        double.TryParse(Console.ReadLine(),out double b);
        Console.WriteLine("Enter third number");
        double.TryParse(Console.ReadLine(),out double c);
        

        //Writing the formula for calculating D
        double d = Math.Sqrt( b*b - 4*a*c);

        //Declaring roots for calculation further
        double x, y;
        x = (-b + d) /(2*a);
        y = (-b - d) / (2*a);

        //printing roots after calculation
        Console.WriteLine($"Roots are {x}, {y}");


    }
}