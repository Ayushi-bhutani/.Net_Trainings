using HotelRoomBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelRoomBookingSystem.Managers
{
    public class HotelManager
    {
        private readonly List<Room> _rooms = new();

        // Add Room
        public void AddRoom(int roomNumber, string type, double price)
        {
            if (_rooms.Any(r => r.RoomNumber == roomNumber))
                throw new Exception("Room already exists.");

            if (price <= 0)
                throw new ArgumentException("Price must be greater than zero.");

            _rooms.Add(new Room
            {
                RoomNumber = roomNumber,
                RoomType = type,
                PricePerNight = price
            });
        }

        // Group Available Rooms By Type
        public Dictionary<string, List<Room>> GroupRoomsByType()
        {
            return _rooms
                .Where(r => r.IsAvailable)
                .GroupBy(r => r.RoomType)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Book Room
        public bool BookRoom(int roomNumber, int nights)
        {
            var room = _rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

            if (room == null || !room.IsAvailable)
                return false;

            double totalCost = room.PricePerNight * nights;

            room.IsAvailable = false;

            Console.WriteLine(
                $"✅ Room {roomNumber} booked for {nights} nights.\n" +
                $"Total Cost: ₹{totalCost}"
            );

            return true;
        }

        // Available Rooms In Price Range
        public List<Room> GetAvailableRoomsByPriceRange(double min, double max)
        {
            return _rooms
                .Where(r => r.IsAvailable &&
                            r.PricePerNight >= min &&
                            r.PricePerNight <= max)
                .OrderBy(r => r.PricePerNight)
                .ToList();
        }

        // Helper: Get All Rooms
        public List<Room> GetAllRooms() => _rooms;
    }
}
