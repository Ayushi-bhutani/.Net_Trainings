using System;

namespace delivery
{
    public class RestaurantOfflineException : Exception
    {
        public string RestaurantId { get; }

        public RestaurantOfflineException(string restaurantId)
            : base($"Restaurant {restaurantId} is currently offline.")
        {
            RestaurantId = restaurantId;
        }

        public RestaurantOfflineException(string restaurantId, Exception innerException)
            : base($"Restaurant {restaurantId} is currently offline.", innerException)
        {
            RestaurantId = restaurantId;
        }
    }
}
