using System;

namespace delivery
{
    public class OrderUpdate
    {
        public string OrderId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string Message { get; set; }
    }

    public class KitchenUpdate
    {
        public string OrderId { get; set; }
        public string ItemName { get; set; }
        public string StationType { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }

    public class PreparationProgress
    {
        public string OrderId { get; set; }
        public double PercentCompleted { get; set; }
    }

    public class RestaurantAcceptance
    {
        public bool IsAccepted { get; set; }
        public string Reason { get; set; }
    }
}
