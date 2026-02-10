using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ticket {
    public class Ticket
    {
        public static int LasticketNo = 1000;

        public int ticketNo;
        public Ticket()
        {
            LasticketNo++;
            ticketNo = LasticketNo;
        }

        public void PrintTicket()
        {
            Console.WriteLine("Ticket Number:" + ticketNo);
        }
        
    }
}