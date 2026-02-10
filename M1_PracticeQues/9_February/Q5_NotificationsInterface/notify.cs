namespace notifications {
    public interface INotifier
    {
        public void Send(string message);
    }

    public class EmailNotifier : INotifier{
            public void Send(string message)
            {
                Console.WriteLine($"{message} from mail");
            }
    }

    public class SmsNotifier : INotifier{
            public void Send(string message)
            {
                Console.WriteLine($"{message} from sms");
            }
    }

    public class WhatsAppNotifier : INotifier{
            public void Send(string message)
            {
                Console.WriteLine($"{message} from whatsapp");
            }
    }

}