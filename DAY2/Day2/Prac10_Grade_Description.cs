using System;
public class Prac10{
    public static char Input(){
        Console.WriteLine("Enter Grade:");
        string? ch = Console.ReadLine();
        if(string.IsNullOrEmpty(ch)){
            Console.WriteLine("Input not provided");
            return '\0';
        }
        
        return char.ToUpper(ch[0]);
    }
    public static void Main10(String[] args){
        char input = Input();
        if(input == '\0') return;
        switch(input){
            case 'E':
                Console.WriteLine("Excellent");
                break;
            case 'V':
                Console.WriteLine("Very Good");
                break;
            case 'G':
                Console.WriteLine("Good");
                break;
            case 'A':
                Console.WriteLine("Average");
                break;
            case 'F':
                Console.WriteLine("Fail");
                break;
            default:
                Console.WriteLine("Invalid Grade");
                break;
        }

    }


}
