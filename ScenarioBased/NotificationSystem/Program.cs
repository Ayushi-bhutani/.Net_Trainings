namespace notification {
    public class Program{

        //entry point 
        public static void Main(String[] args){

            //object of the core class accessing interface and different methods 
            NotificationService service = new NotificationService();
            service.Notify(new EmailNotification(), "Hello via email");
            service.Notify(new SMSNotification(), "Hello via SMS");
            service.Notify(new WhatsAppNotification(), "Hello via Whatsapp");
            

        }
    }
}