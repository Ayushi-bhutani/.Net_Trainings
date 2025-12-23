using System;
public class Prac6
{
    //function for taking input
    static int Input()
    {
        Console.WriteLine("Enter Bill");
        int.TryParse(Console.ReadLine(), out int bill);
        return bill;
    }

    //entry point
    public static void Main6(String[] args)
    {
        int bill = Input();

        // if-else conditions for checking percentage of bill to be paid
        if(bill <=199) Console.WriteLine(1.20*bill);
        else if(bill >=200 && bill <= 400) Console.WriteLine(1.50*bill);
        else if(bill >= 400 && bill <= 600 ) Console.WriteLine(1.80*bill);
        else if(bill > 400) bill += 15/100 * bill;
        else
        {
            Console.WriteLine(2*bill);
        }



    }
}