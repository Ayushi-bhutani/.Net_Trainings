using IndianTax;
using USTax;

public class Program{
    public static void Main(String[]args){
        IndianEmployee indian = new IndianEmployee(10000);
        // USEmployee us = new IndianEmployee(2000);
        Console.WriteLine(indian.calcTax());
    }
}