namespace ticket
{
    public class Program
    {
        public static void Main(string[] args){
            Console.WriteLine("Enter number of tickets");
            int n = int.Parse(Console.ReadLine());

            Ticket[] tickets = new Ticket[n];
            for(int i=0; i<n; i++)
            {
                tickets[i] = new Ticket();
                tickets[i].PrintTicket();
            }
        }
    }
}