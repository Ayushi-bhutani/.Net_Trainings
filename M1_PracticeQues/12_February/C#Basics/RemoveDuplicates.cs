// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Collections.Generic;

public class HelloWorld
{
    public static List<int> RemoveDuplicates(List<int> input)
    {
        HashSet<int> hash = new HashSet<int>();
        foreach(var item in input)
        {
            hash.Add(item);
        }
        List<int> ans = new List<int>();
        foreach(var item in hash)
        {
            ans.Add(item);
        }
        return ans;
    }
    public static void Main(string[] args)
    {
        List<int> list = new List<int>();
        
        list.Add(1);
        list.Add(1);
        list.Add(2);
        list.Add(2);
        list.Add(3);
        
        list = RemoveDuplicates(list);
        foreach(var item in list){
            Console.Write(item);
        }
        
    }
}