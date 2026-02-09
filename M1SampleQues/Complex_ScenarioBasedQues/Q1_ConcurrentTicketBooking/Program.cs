namespace ticket
{
    public class Program
    {
        public static async Task Main(String[] args)
        {
            var service = new TicketBookingService(10);
            var tasks = new List<Task>();
            for(int i = 1; i<=5; i++)
            {
                int userNum = i;
                tasks.Add(Task.Run(() =>
                {
                    bool success = service.BookSeat(1, $"User{userNum}");

                    Console.WriteLine(
                        success
                        ? $"User{userNum} booked successfully"
                        : $"User{userNum} failed"
                    );
                }));
            }
            await Task.WhenAll(tasks);
        }
    }
}