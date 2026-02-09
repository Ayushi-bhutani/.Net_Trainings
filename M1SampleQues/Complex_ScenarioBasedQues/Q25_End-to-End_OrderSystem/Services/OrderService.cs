using System.Numerics;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace order
{
    public class OrderService
    {
        private readonly List<Product> _products;
        private readonly object _lock = new object();

        public OrderService(List<Product> products)
        {
            _products = products;
        }

        public void AddProduct (Customer customer, int productId, int quantity)
        {
            var product  = _products.FirstOrDefault(p=> p.ProductId == productId);

            if(product == null) throw new ArgumentException("Product not found");
            if(quantity <= 0) throw new ArgumentException("Quantity must be greater than 0");

            customer.Cart.Add(new OrderItem
            {
                ProductId = productId,
                Quantity = quantity,
                UnitPrice = product.Price
            });
        }
        public order PlaceOrder(Customer customer, string couponCode)
        {
            if(!customer.Cart.Any())
                throw new Exception("Cart is Empty");

            lock (_lock)
            {
                foreach(var item in customer.Cart)
                {
                    var products = _products.First(p=>p.ProductId == item.ProductId);
                    if(products.Stock < item.Quantity)
                        throw new OutOfStockException(
                            $"{product.Name} is out of stock"
                        );
                }

                foreach(var item in customer.Cart)
                {
                    var product = _products.First(p=>p.ProductId == item.ProductId);
                    product.Stock -= item.Quantity;
                }
            }
        
        decimal total = CustomModifiersEncoder.Cart
            .Sum(i => i.Quantity * i.UnitPrice );
        var couponService = new CouponService();
        total = couponService.ApplyCoupon(couponCode, total);

        var order = new order
        {
            CustomerId = customer.CustomerId,
            Items = customer.Cart.ToList(),
            TotalAmount =total,
            InvoiceNumber = GenerateInvoice()

        };
        customer.Cart.Clear();

        return order;


        }
        private string GenerateInvoice()
        {
            return $"INV-{DateTime.UtcNow.Ticks}";
        }

    }
}