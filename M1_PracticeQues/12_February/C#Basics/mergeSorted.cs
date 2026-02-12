// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Collections.Generic;
public class HelloWorld
{
    
    public static void Main(string[] args)
    {
        int[] arr1 = {1,2,3,2,3,1,4};
        int[] arr2 = {2,3,4,6};
        
        int size = arr1.Length + arr2.Length;
        int[] merged = new int[size];
        
        Array.Sort(arr1);
        Array.Sort(arr2);
    
        int i = 0, j=0, k=0;
        
        while( i < arr1.Length && j < arr2.Length)
        {
            if(arr1[i] < arr2[j])
            {
                merged[k++] = arr1[i++];
            }
            else 
            {
                merged[k++] = arr2[j++];
            }
        }
        
        while( i < arr1.Length)
        {
            merged[k++] = arr1[i++];
        }
        while(j < arr2.Length)
        {
            merged[k++] = arr2[j++];
        }
        for( int itr =0; itr< merged.Length; itr++){
            Console.Write(merged[itr]);
        }
        
        
        
        
        
        
        
        
         
        
        Console.WriteLine();
        
    }
}