namespace ecommerce{
    public class Product {
        public int ProductId{get; set;}
        public string Name{get; set;}
        public decimal Price{get; set;}

        public Product(int id, string name, decimal price){
            ProductId = id;
            Name = name;
            Price = price;


        }
    }

    public class Order {
        private List<Product> products = new List<Product> ();
        public void AddProduct(Product product){
            products.Add(product);
        }

        public decimal GetTotalAmount(){
            return products.Sum(p=>p.Price);
        }
    }

    public interface IPayment{
        void Pay(decimal amount);
    } 

    public class CreditCardPayment : IPayment{
        public void Pay(decimal amount){
            Console.WriteLine($"Paid {amount} using Credit Card");
        }


    }

    public class UPIPayment : IPayment{
        public void Pay(decimal amount){
            Console.WriteLine($"Paid {amount} using UPI");
        }

        
    }
    public interface INotification{
        void Send(string message);
    } 

    public class EmailNotification : INotification {
        public void Send(string message){
            Console.WriteLine("Email Sent: " + message);
        }
    }


    public class OrderProcessor{
        private readonly IPayment payment;
        private readonly INotification notification ;
        public OrderProcessor(IPayment payment, INotification notification){
            this.payment = payment;
            this.notification = notification;
        }

        public void ProcessOrder(Order order){
            decimal amount = order.GetTotalAmount();
            payment.Pay(amount);
            notification.Send("Order processed successfully");
        }
    }
}