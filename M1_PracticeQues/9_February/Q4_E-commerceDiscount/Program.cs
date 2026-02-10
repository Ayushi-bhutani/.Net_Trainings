namespace ecommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter type");
            string type = Console.ReadLine();
            double amount = 1000;
            FestivalDiscount f = new FestivalDiscount();
            MemberDiscount m = new MemberDiscount();
            double ans ;
            if(type == "F")
            {
                ans = f.GetFinalAmount(amount);

            }else
            {
                ans = m.GetFinalAmount(amount);
            }

            Console.WriteLine(ans);
        }
    }
}