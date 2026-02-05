using HotelRoomBookingSystem.Managers;
using System;

class Program
{
    static void Main()
    {
        var hotel = new HotelManager();

        // 1️⃣ Add Rooms
        hotel.AddRoom(101, "Single", 2000);
        hotel.AddRoom(102, "Double", 3500);
        hotel.AddRoom(103, "Suite", 6000);
        hotel.AddRoom(104, "Single", 2200);

        // 2️⃣ Display Available Rooms Grouped
        Console.WriteLine("🏨 Available Rooms Grouped By Type:\n");

        var grouped = hotel.GroupRoomsByType();

        foreach (var type in grouped)
        {
            Console.WriteLine($"--- {type.Key} ---");
            type.Value.ForEach(r => Console.WriteLine(r));
            Console.WriteLine();
        }

        // 3️⃣ Book Room
        Console.WriteLine("\n📌 Booking Room 102 for 3 nights...\n");
        hotel.BookRoom(102, 3);

        // 4️⃣ Price Range Search
        Console.WriteLine("\n💰 Rooms Between ₹2000 – ₹4000:\n");

        var budgetRooms =
            hotel.GetAvailableRoomsByPriceRange(2000, 4000);

        budgetRooms.ForEach(r => Console.WriteLine(r));

        // 5️⃣ All Rooms Status
        Console.WriteLine("\n📋 All Room Status:\n");

        hotel.GetAllRooms()
             .ForEach(r => Console.WriteLine(r));
    }
}
