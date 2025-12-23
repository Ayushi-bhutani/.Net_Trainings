using System;
public class Prac16{

    //taking input n
    public static int input(){
        Console.WriteLine("Enter a number");
        int.TryParse(Console.ReadLine(), out int a);
        return a;
    }

    //defining function for fibonacci series
    static int fib(int n){
        if(n<=1) return n;
        return fib(n-1) + fib(n-2);
    }

    //main function where execution starts
    public static void Main16(String[] args){
        int n = input();
        for(int i =0; i<n; i++){
            Console.WriteLine(fib(i) + " ");
        }
        

    }
}