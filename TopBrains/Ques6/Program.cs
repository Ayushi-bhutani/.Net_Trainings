public class Program {
    public static void Main(String[] args){
        Console.WriteLine("Enter three numbers");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        if(a > b){
            if( a > c){
                Console.WriteLine($"{a} is largest");
            }
        }else{
            if(b>c){
                Console.WriteLine($"{b} is largest");
            }else{
                Console.WriteLine($"{c} is largest");
            }
        }
    }
}