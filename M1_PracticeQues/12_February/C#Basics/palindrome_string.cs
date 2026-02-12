// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class HelloWorld
{
    public static bool IsPalindrome(string input)
    {
        int i =0, j = input.Length-1;
        while(i<j)
        {
            if(input[i] != input[j]){
                return false;
            }
            i++;
            j--;
        }
        return true;
    }
    public static void Main(string[] args)
    {
        string input = "eye";
        bool ans = HelloWorld.IsPalindrome(input);
        Console.WriteLine(ans);
    }
}