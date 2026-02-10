using System.ComponentModel;
using System.Linq.Expressions;

namespace notifications
{
    public class Program
    {
        public static void Main(string[] args)

        {
            string message = "HI";
            List <INotifier> notify =  new List<INotifier>(){
                new EmailNotifier(),
                new SmsNotifier(),
                new WhatsAppNotifier()
            };
            foreach(var notifiers in notify)
            {
                notifiers.Send(message);
            }
            
        }
    }
}