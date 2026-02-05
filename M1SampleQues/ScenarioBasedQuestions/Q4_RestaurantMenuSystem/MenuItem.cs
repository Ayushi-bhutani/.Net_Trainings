namespace RestaurantMenuManagement.Models
{
    public class MenuItem
    {
        public string ItemName { get; set; }
        public string Category { get; set; }   // Appetizer / Main Course / Dessert
        public double Price { get; set; }
        public bool IsVegetarian { get; set; }

        public override string ToString()
        {
            return $"{ItemName} | {Category} | ₹{Price} | " +
                   $"{(IsVegetarian ? "Veg" : "Non-Veg")}";
        }
    }
}
