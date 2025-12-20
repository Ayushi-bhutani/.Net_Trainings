using System;
public class Height{
    public static void Main3(String[] args){
        //taking input for height
        Console.WriteLine("Enter Height");
        String? input = Console.ReadLine();

        // applying if else-if conditions
        if(int.TryParse(input, out int num)){
            if(num < 150 ){
                Console.WriteLine("Dwarf");
            }else if(num > 150 && num < 165){
            Console.WriteLine("Tall");
        }
        else if(num  > 190){
            Console.WriteLine("Abnormal");
        }
        }
        
    }
}