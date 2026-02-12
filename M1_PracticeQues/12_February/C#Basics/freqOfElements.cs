// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Collections.Generic;
public class HelloWorld
{
    public static void Main(string[] args)
    {
        int[] arr = {1,2,3,4,5,1,2,3};
        Dictionary<int, int> freq = new Dictionary<int, int>();
        
        foreach(int num in arr)
        {
            if(freq.ContainsKey(num)) 
                freq[num]++;
            else 
                freq[num] = 1;
        }
        foreach( var item in freq )
        {
            Console.WriteLine($"{item.Key} - {item.Value}");
        }
    }
}