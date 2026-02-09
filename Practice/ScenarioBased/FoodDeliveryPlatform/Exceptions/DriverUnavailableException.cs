using System;

namespace delivery
{
    public class DriverUnavailableException : Exception
    {
        public DriverUnavailableException() 
            : base("No available drivers for the order.") { }

        public DriverUnavailableException(string message) : base(message) { }

        public DriverUnavailableException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
