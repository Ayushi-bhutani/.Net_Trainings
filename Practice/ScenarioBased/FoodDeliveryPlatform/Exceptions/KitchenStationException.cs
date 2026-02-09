using System;

namespace QuickBite.Exceptions
{
    public class KitchenStationException : Exception
    {
        public string StationId { get; }

        public KitchenStationException(string stationId, string message) 
            : base($"Station {stationId}: {message}")
        {
            StationId = stationId;
        }

        public KitchenStationException(string stationId, string message, Exception innerException) 
            : base($"Station {stationId}: {message}", innerException)
        {
            StationId = stationId;
        }
    }
}
