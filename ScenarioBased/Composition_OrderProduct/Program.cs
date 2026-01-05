namespace composition{
    public class Product
    {
        public int ProductId{get; set;}
        public string Name{get; set;}

        public decimal Price{get; set;}

        public Product(int productId, string name, decimal price)
        {
            ProductId=productId;
            Name = name;
            Price = price;
        }


    }

    public class Order
    {
        public int OrderId{get; set;}
        private List<Product> products;
        public Order(int orderId)
        {
            OrderId = orderId;
            products = new List<Product>();

        }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }

        public decimal GetTotalPrice()
        {
            return products.Sum(p=>p.Price);
        } 

        
        public List<Product> GetProducts()
        {
            return products;
        }
    }

    public class Program
    {
        public static void Main(String[] args)
        {
            Product p1 = new Product(1, "Laptop", 80000);
            Product p2 = new Product(2, "Mouse", 1500);
            
            Order order = new Order(101);
            order.AddProduct(p1);
            order.AddProduct(p2);
            decimal total  = order.GetTotalPrice();
            Console.WriteLine("total price: "+total);
            order.GetProducts();

        }
    }
}