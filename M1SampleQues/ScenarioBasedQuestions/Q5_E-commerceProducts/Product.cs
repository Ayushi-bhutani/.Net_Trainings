namespace ECommerceProductCatalog.Models
{
    public class Product
    {
        public string ProductCode { get; set; }   // P001, P002...
        public string ProductName { get; set; }
        public string Category { get; set; }      // Electronics / Clothing / Books
        public double Price { get; set; }
        public int StockQuantity { get; set; }

        public override string ToString()
        {
            return $"{ProductCode} | {ProductName} | {Category} | ₹{Price} | Stock: {StockQuantity}";
        }
    }
}
