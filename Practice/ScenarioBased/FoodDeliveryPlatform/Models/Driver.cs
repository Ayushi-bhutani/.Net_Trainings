namespace delivery
{
    
    public class Driver
    {
        public string DriverId { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public Location CurrentLocation { get; set; }
        public int ETA { get; set; } // in minutes
    }

    public class DriverAssignment
    {
        public string OrderId { get; set; }
        public string DriverId { get; set; }
    }

    public class DriverLocation
    {
        public string DriverId { get; set; }
        public Location CurrentLocation { get; set; }
    }

    public class AvailableDriver : Driver
    {
    }

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}

