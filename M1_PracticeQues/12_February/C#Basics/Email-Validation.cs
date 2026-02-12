// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class HelloWorld
{
    public static bool isValid(string input)
    {
        if(string.IsNullOrWhiteSpace(input)) return false;
        
        bool ans = true;
        int cnt1 =0;
       
        foreach(var i in input)
        {
            if(i == '@'){
                cnt1++;
            }
            
            if( i == '!' || i == '#' ) return false;
        }
        if(cnt1  != 1 )
        {
            return false;
        }
        string[] parts = input.Split
            ('@', StringSplitOptions.RemoveEmptyEntries);
        
        if(parts.Length != 2) return false;
        
        string part1 = parts[0];
        string part2 = parts[1];
        
        if(part1.Length == 0) return false;
        if(part2.StartsWith('.') || part2.EndsWith('.')) return false;
        
        if(!part2.Contains('.')) return false;
        foreach(var ch in part1)
        {
            if(!char.IsLetterOrDigit(ch) )
            {
                return false;
            }
        }
        foreach(var ch in part2){
            if(!(char.IsLetterOrDigit(ch) || ch == '.')) return false;
        }
        return true;
    }
    public static void Main(string[] args)
    {   
        string input = "ayush@gmail.com";
        Console.WriteLine(isValid(input));      
        
    }
}