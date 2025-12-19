// See https://aka.ms/new-console-template for more information
using System;
public class Program
{
    public static void Main2()
    {
       
        int count=0;
        Console.WriteLine("Enter a number:");
        int n = int.Parse(Console.ReadLine());
        for(int i=3; i<n; i=i+2)
        {

            for(int j=1; j<=i; j++)
            {
                if(i%j==0) 
                {
                    count++;
                }
            }

            // Console.WriteLine("iNTERNAL COUNT: " + count);
            if (count==2) 
            {
                Console.WriteLine("Prime :" + i);
            }
            count=0;


        }

    }
}

