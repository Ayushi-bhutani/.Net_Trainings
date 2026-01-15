using System.Collections.Generic;

namespace ride
{
    public class Program
    {
        public static void Main(String[] args)
        {
            var rides = new List<Ride>{
                new AutoRide(5),
                new CabRide(10),
                new PremiumCabRide(10)
            };

            double total = rides.Sum(r => r.GetFare());
            Console.WriteLine(total);
        }
    }
}