using System;
public class Prac2{
    public static void Main4(){
        // Taking inputs for three Integers
        Console.WriteLine("Enter first Number:");
        int.TryParse(Console.ReadLine(), out int a);
        Console.WriteLine("Enter second Number:");
        int.TryParse(Console.ReadLine(), out int b);
        Console.WriteLine("Enter third Number:");        
        int.TryParse(Console.ReadLine(), out int c);

        // Checking for the greatest numbers using nested if conditions
        if(a>b){
            if(a>c){
                Console.WriteLine($"{a} is greatest");
            }else{
                Console.WriteLine($"{c} is greatest");
            }
        }else{
            if(b>c){
                Console.WriteLine($"{b} is greatest");
            }else{
                Console.WriteLine($"{c} is greatest");
            }
        }



    }
}