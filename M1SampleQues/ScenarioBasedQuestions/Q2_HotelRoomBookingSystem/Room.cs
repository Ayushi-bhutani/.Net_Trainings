namespace HotelRoomBookingSystem.Models
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }   // Single / Double / Suite
        public double PricePerNight { get; set; }
        public bool IsAvailable { get; set; } = true;

        public override string ToString()
        {
            return $"Room {RoomNumber} | {RoomType} | ₹{PricePerNight} | " +
                   $"{(IsAvailable ? "Available" : "Booked")}";
        }
    }
}
