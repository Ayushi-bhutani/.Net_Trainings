public interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; set;}
    Category Category { get; }
}

public enum Category { Electronics, Clothing, Books, Groceries }

// 1. Create a generic repository for products
public class ProductRepository<T> where T : class, IProduct
{
    private List<T> _products = new List<T>();
    
    // TODO: Implement method to add product with validation
    public void AddProduct(T product)
    {
        // Rule: Product ID must be unique
        // Rule: Price must be positive
        // Rule: Name cannot be null or empty
        // Add to collection if validation passes
        if(product == null) throw new Exception("Product cannot be null");
        
        if(_products.Any(p => p.Id == product.Id)) throw new Exception("Id can't be duplicate");
        
        if(product.Price <= 0) throw new Exception("price should be positive");
        
        if(string.IsNullOrWhiteSpace(product.Name)) throw new Exception("name can't be null");
        
        _products.Add(product);
    }
    
    // TODO: Create method to find products by predicate
    public IEnumerable<T> FindProducts(Func<T, bool> predicate)
    {
        // Should return filtered products
        
        return _products.Where(predicate);
    }
    
    // TODO: Calculate total inventory value
    public decimal CalculateTotalValue()
    {
        // Return sum of all product prices
        decimal TotalValue = 0;
        foreach(var item in _products){
            TotalValue += item.Price;
        }
        
        return TotalValue;
        
    }
}

// 2. Specialized electronic product
public class ElectronicProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Electronics;
    public int WarrantyMonths { get; set; }
    public string Brand { get; set; }
}

// 3. Create a discounted product wrapper
public class DiscountedProduct<T> where T : IProduct
{
    private T _product;
    private decimal _discountPercentage;
    
    public DiscountedProduct(T product, decimal discountPercentage)
    {
        // TODO: Initialize with validation
        // Discount must be between 0 and 100
        
        if(discountPercentage < 0 || discountPercentage > 100){
            throw new Exception ("Discount must be between 0 and 100");
        }
        _product = product;
        _discountPercentage = discountPercentage;
    }
    
    // TODO: Implement calculated price with discount
    public decimal DiscountedPrice => _product.Price * (1 - _discountPercentage / 100);
    
    // TODO: Override ToString to show discount details
    public override string ToString(){
        return $" Discounted Price: {DiscountedPrice}";
    }
}

// 4. Inventory manager with constraints
public class InventoryManager
{
    // TODO: Create method that accepts any IProduct collection
    public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
    {
        // a) Print all product names and prices
        // b) Find the most expensive product
        // c) Group products by category
        // d) Apply 10% discount to Electronics over $500
       
        foreach( var item in products)
        {
            Console.WriteLine($"{item.Name} - {item.Price}" );
        }
        
        var mostExpensiveProduct = products
                            .OrderByDescending(p=>p.Price)
                            .FirstOrDefault();
                            
        if (mostExpensiveProduct != null) Console.WriteLine($"{mostExpensiveProduct.Name} - {mostExpensiveProduct.Price}");
                
        var grouped = products.GroupBy(p=>p.Category);
        foreach( var group in grouped)
        {
            Console.WriteLine($"category {group.Key}");
            foreach( var item in group)
            {
                Console.WriteLine($" {item.Name} - {item.Price}");
            }
        }
        
        var discounted = products
            .Where(p=>p.Category == Category.Electronics && p.Price > 500)
            .Select (p => new{
                p.Name,
                OriginalPrice = p.Price,
                DiscountedPrice = p.Price*0.90m
                
            });
            
        foreach(var item in discounted){
            Console.WriteLine($"{item.Name} - {item.DiscountedPrice}");
        }
            
    }
    
    // TODO: Implement bulk price update with delegate
    public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster) 
        where T : IProduct
    {
        // Apply priceAdjuster to each product
        // Handle exceptions gracefully
        foreach(var item in products){
            try{
                decimal newPrice = priceAdjuster(item);
                if(newPrice < 0) throw new Exception("Price cannot be negative");
                item.Price = newPrice;
            }catch(Exception ex){
                Console.WriteLine(
                    $"error updating {item.Name} to {ex.Message}"
                    );
            }
        }
        
    }
}

public class Program
{
    public static void Main()
    {
        var repo = new ProductRepository<ElectronicProduct>();

        var p1 = new ElectronicProduct
        {
            Id = 1,
            Name = "iPhone 15",
            Price = 1200,
            Brand = "Apple",
            WarrantyMonths = 24
        };

        var p2 = new ElectronicProduct
        {
            Id = 2,
            Name = "Samsung TV",
            Price = 800,
            Brand = "Samsung",
            WarrantyMonths = 18
        };

        var p3 = new ElectronicProduct
        {
            Id = 3,
            Name = "Sony Headphones",
            Price = 300,
            Brand = "Sony",
            WarrantyMonths = 12
        };

        // Add products
        repo.AddProduct(p1);
        repo.AddProduct(p2);
        repo.AddProduct(p3);

        // Find by brand
        var sony = repo.FindProducts(p => p.Brand == "Sony");

        Console.WriteLine("Sony Products:");
        foreach (var p in sony)
            Console.WriteLine(p.Name);

        // Total value
        Console.WriteLine(
            "\nTotal Value: " +
            repo.CalculateTotalValue());

        // Discount wrapper test
        var discount =
            new DiscountedProduct<ElectronicProduct>(p1, 10);

        Console.WriteLine("\nDiscount Test:");
        Console.WriteLine(discount);

        // Inventory processing
        var manager = new InventoryManager();
        manager.ProcessProducts(
            repo.FindProducts(p => true));

        // Bulk update
        manager.UpdatePrices(
            repo.FindProducts(p => true).ToList(),
            p => p.Price * 1.05m);

        Console.WriteLine("\nAfter Price Update:");
        foreach (var p in repo.FindProducts(x => true))
            Console.WriteLine($"{p.Name} - {p.Price}");
    }
}
