using System;
public class Prac5{

    public static void Main5(String[] args){

        //taking all three subject marks input
        Console.WriteLine("Enter Maths marks:");
        int.TryParse(Console.ReadLine(), out int a);
        Console.WriteLine("Enter Physics marks:");
        int.TryParse(Console.ReadLine(), out int b);
        Console.WriteLine("Enter Chemistry marks:");
        int.TryParse(Console.ReadLine(), out int c);

        //checking condition if admmission is eligible for candidate or not using if 
        if(a >= 65 && b >= 55 && c>=50 && ((a+b+c >= 180) || (a+b >=140))){
            Console.WriteLine("Eligible");
        }else{
            Console.WriteLine("Not Eligible");
        }

    }
}