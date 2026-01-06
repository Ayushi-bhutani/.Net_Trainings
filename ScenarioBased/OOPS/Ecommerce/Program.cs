namespace ecommerce{
    public class Program {
        public static void Main(String[] args){
            Order order = new Order();
            order.AddProduct(new Product(1,"Laptop", 80000));
            order.AddProduct(new Product(2,"Mouse", 1500));

            IPayment payment = new CreditCardPayment();
            INotification notification = new EmailNotification();

            OrderProcessor processor = new OrderProcessor(payment, notification);
            processor.ProcessOrder(order);
        }
    }
}