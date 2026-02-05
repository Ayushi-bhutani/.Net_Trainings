using System;
using System.Collections.Generic;

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public List<FoodItem> Items { get; set; } = new List<FoodItem>();
    public DateTime OrderTime { get; set; }
    public string Status { get; set; }   // Pending / Delivered
    public double TotalAmount { get; set; }
}
