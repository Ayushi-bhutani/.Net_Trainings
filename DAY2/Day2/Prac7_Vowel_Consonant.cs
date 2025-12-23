using System;
public class Prac7{

    //Taking character Input
    static char Input(){
        Console.WriteLine("Enter a character:");
        string? input = Console.ReadLine();

        //if input is not given, program will still not crash
        if(string.IsNullOrEmpty(input)){
            Console.WriteLine("No input provided");
            return '\0';
        }

        //converting string to character, matching return type of function
        return char.ToLower(input[0]);

    }

    //entry point of program
    public static void Main7(String[]args){
        char input = Input();
        switch(input){
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                Console.WriteLine("It's a vowel");
                break;
            default:
                Console.WriteLine("Not a vowel");
                break;
        }

    }
}