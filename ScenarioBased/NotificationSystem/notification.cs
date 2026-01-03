namespace notification {


    public interface INotification{
        void Send(string message);
    }
    public class EmailNotification : INotification{
        public void Send(string message){
            Console.WriteLine("Email Sent: "+message);
        }

    }
    
    public class SMSNotification : INotification{
        public void Send(string message){
            Console.WriteLine("SMS Sent: "+message);
        }
    }

    public class WhatsAppNotification : INotification{
        public void Send(string message){
            Console.WriteLine("whatsapp message sent:"+message);
        }
    }

    public class NotificationService{
        public void Notify(INotification n, string message){
            n.Send(message);
        }
    }


}