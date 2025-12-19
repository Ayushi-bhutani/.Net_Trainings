using System;
public class Age{
    public static void Agee(){
        Console.WriteLine("Enter Age:");
        string? input = Console.ReadLine();
        if(int.TryParse(input,out int age)){
            if(age >= 18){
                Console.WriteLine("Adult");
            }else{
                Console.WriteLine("Minor");
            }
        }
    }
}