using System;
public class Prac11{
    public static (int day, int month, int year)Input(){
        Console.WriteLine("Enter day:");
        int.TryParse(Console.ReadLine(), out int day);
        Console.WriteLine("Enter month:");
        int.TryParse(Console.ReadLine(), out int month);
        Console.WriteLine("Enter year:");
        int.TryParse(Console.ReadLine(), out int year);
        return (day, month, year);

    }
    public static bool IsLeapYear(int year){
        if(year%400==0) return true;
        if(year%100==0) return false;
        return year%4==0;
    }
    public static bool Check(int day, int month, int year){
        if(year < 1 || month < 1 || month > 12 || day < 1){
            return false;
        }
        int [] daysInMonth = { 
            31,
            28,
            31,
            30,
            31,
            30,
            31,
            31,
            30,
            31,
            30,
            31
        };
        if(month == 2 && IsLeapYear(year)){
            return day <= 29;
        }
        return day < daysInMonth[month-1];
    }
    public static void Main(String[] args){
        var (day, month,  year) = Input();
        if(Check(day,month,year)){
            Console.WriteLine("Valid Date");
        }else{
            Console.WriteLine("Invalid Date");
        }

    }
}