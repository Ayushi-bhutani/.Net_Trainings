// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        int[] arr = {1,2,3,4,5};
        for(int i=0; i<arr.Length; i++){
            Console.Write(arr[i]);
        }
        Console.WriteLine();
    
        int maxi = arr[0];
        foreach(int a in arr){
            if(a > maxi){
                maxi = a;
            }
        }
        Console.WriteLine(maxi);
        
    }
}