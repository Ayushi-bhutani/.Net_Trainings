// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Collections.Generic;
public static class HelloWorld
{
    public static bool IsValidString(string input)
    {
        foreach( char ch in input)
        {
            if(!char.IsLetter(ch))
            {
                return false;
            }
        }
        return true;
    }
    
    public static void Main(string[] args)
    {
        Console.WriteLine("Question1");
        string a = Console.ReadLine ();
        int.TryParse(a,out int num1);
        Console.WriteLine(num1);
        
        Console.WriteLine("Question2");
        string b = Console.ReadLine ();
        double.TryParse(b,out double num2);
        Console.WriteLine("double precision"+num2);
        
        Console.WriteLine("Question3");
        string input = Console.ReadLine();
        string[] parts = input.Split
            (" ", StringSplitOptions.RemoveEmptyEntries);
        foreach(var item in parts)
        {
            int.TryParse(item, out int num);
            Console.WriteLine(num);
        }
        
        Console.WriteLine("Question4");
        List<double> list = new List<double>();
        string input = Console.ReadLine();
        string[] parts = input.Split
                (" ", StringSplitOptions.RemoveEmptyEntries);
        foreach( var item in parts)
        {
            double.TryParse(item, out double num);
            list.Add(num);
        }
        foreach(var item in list)
        {
            Console.Write(item);
        }
        
        Console.WriteLine("Question5");
        string input = Console.ReadLine();
        bool ans = IsValidString(input);
        Console.WriteLine(ans);
        
    }
}