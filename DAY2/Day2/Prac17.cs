using System;
public class Prac17{
    
    //taking input 
    static int Input(){
        Console.WriteLine("Enter a number");
        int.TryParse(Console.ReadLine(), out int a);
        return a;
    }

    //defining function to check number is prime or not
    static bool IsPrime(int n){
        if(n<= 1) return false;
        if(n == 2) return true;
        if(n%2==0) return false;
        for(int i = 3; i*i<=n; i+=2 ){
            
           if(n%i==0) return false;
        }
        return true;
        
       
    } 

    //main function entry point for execution
    public static void Main17(String[] args){
        int n = Input();
        bool output = IsPrime(n);
        Console.WriteLine(output);

        



    }
}
