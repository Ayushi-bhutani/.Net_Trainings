using System;
public class Prac3 {
    public static void Yearr(){
        // taking input for year
        Console.WriteLine("Enter a year");
        int.TryParse(Console.ReadLine(),out int year);

        // checking with leap year condition 
   
        if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0)){
            Console.WriteLine("Leap Year");
        }else{
            Console.WriteLine("Not a Leap Year");
        }
    }
}