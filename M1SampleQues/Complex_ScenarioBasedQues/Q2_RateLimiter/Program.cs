using System.Net.Quic;

namespace rate
{
    public class Program
    {
        public static void Main(String[] args)
        {
            var limiter = new RateLimiter (
                maxRequests : 5,
                WindowSize: TimeSpan.FromSeconds(10)
            );

            string client = "ClientA";
            for(int i = 1; i<= 7; i++)
            {
                bool allowed = limiter.AllowRequest(client, DateTime.utcNow);

                Console.WriteLine(
                    $"Request {i} : {(allowed ? "Allowed" : "Blocked")}"
                );

                System.Threading.Thread.Sleep(1000);
            }
            


        }
    }
}