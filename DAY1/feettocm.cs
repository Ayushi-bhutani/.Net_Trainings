using System;
public class Feettocm{ // not necessary to give class name as the file name
    public static void Main(){
        Console.WriteLine("Enter input:");
        string? number = Console.ReadLine();
        double cmperfeet = 30.48;
        if(!double.TryParse(number, out double feet)){
            Console.WriteLine("Invalid");
        }
        Console.WriteLine( cmperfeet*feet);

        
        
    }
}