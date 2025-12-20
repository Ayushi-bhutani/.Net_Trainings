using System;
public class EvenNumbers
{
    static bool isEven(int num)
    {
        if(num%2==0) return true;
        else return false;
    }

    public static void Main2()
    {
        Console.WriteLine("Enter a Number:");
        string? input = Console.ReadLine();
        string output = string.Empty;
        while(input != "Q" || input != "q")
        {
            if(int.TryParse(input, out int num))
            {
                output = isEven(num) ? "It's an Even Number" : "It's an Odd Number";
                Console.WriteLine(output);
            }else if(input == "q" || input == "Q"){
                break;
            }
            else
            {
                Console.WriteLine("Enter a valid number or quit");
            }
            Console.WriteLine("Enter a Number:");
            input = Console.ReadLine();

        }

        
        
    }
}