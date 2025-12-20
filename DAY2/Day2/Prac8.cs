using System;
public class Prac8{

    //taking three sides input
    static (int,int,int) input(){
        Console.WriteLine("Enter first side length:");
        int.TryParse(Console.ReadLine(), out int a);
        Console.WriteLine("Enter second side length:");
        int.TryParse(Console.ReadLine(), out int b);
        Console.WriteLine("Enter third side length:");
        int.TryParse(Console.ReadLine(), out int c);
        return (a,b,c);

    }

    //condition for checking type of triangle
    static void checkTriangleType(int a, int b, int c){
        if((a+b) <= c || (a+c) <= b || (b+c) <= a){
            Console.WriteLine("Not a valid Triangle");
            return;
        }

        if(a==b && b==c){
            Console.WriteLine("Equilateral Triangle");
        }
        else if(a==b || b==c || c==a){
            Console.WriteLine("Isosceles Triangle");
        }else{
            Console.WriteLine("Scalene Triangle");
        }
    }
    

    // entry point of program
    public static void Main8(String[] args){
        var(a,b,c) = input();
        checkTriangleType(a,b,c);

    }
}