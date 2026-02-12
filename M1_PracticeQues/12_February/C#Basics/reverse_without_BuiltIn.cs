// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public static class HelloWorld
{
    public static string Reverse(string input)
    {
       
        char[] ans = new char[input.Length];
        
        int j = 0; 
        
        for(int i = input.Length-1; i >= 0;  i--)
        {
            ans[j] = input[i];
            j++;
        }
        return (new string(ans));
        
    }
    public static void Main(string[] args)
    {
        string input = "ayushi";
        string reversed = HelloWorld.Reverse(input);
        Console.WriteLine(reversed);
    }
}