public class Program {
    public static void Main(String[] args){
        Console.WriteLine("Enter initial balance and transactions");
        int balance = int.Parse(Console.ReadLine());
        string[] trans = Console.ReadLine().Split();
        int[] transaction = trans.Select(int.Parse).ToArray();
        foreach(var i in transaction ){
            if(i >= 0){
                balance += i;
            }else{
                int withdraw = -i;
                if(balance >= i){
                    balance -= i;
                }
                
            }

        }
        Console.WriteLine(balance);

    }
}