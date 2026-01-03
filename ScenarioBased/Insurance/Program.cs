namespace insurance {
    public class Program{
        public static void Main(String[] args){
            Insurance i ;
            i = new Health();
            Console.WriteLine("health: "+i.CalculatePremium(1000));

            i = new Life();
            Console.WriteLine("life: "+i.CalculatePremium(1000));

            i = new Vehicle();
            Console.WriteLine("Vehicle: "+i.CalculatePremium(1000));




        }
    }
}