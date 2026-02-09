using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace ticket {
    public class TicketBookingService
    {
        private readonly Dictionary<int, Seat> _seats;
        private readonly object _lock = new object();

        public TicketBookingService(int totalSeats)
        {
            _seats = new Dictionary<int, Seat>();
            for(int i = 1; i<= totalSeats; i++)
            {
                _seats[i] = new Seat {
                    SeatNo = i,
                    IsBooked = false,
                    BookedBy = null

                };
            }
        }
        public bool BookSeat(int seatNo, string userId)
        {
            if(string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("Invalid user id");
            lock (_lock)
            {
                if(!_seats.ContainsKey(seatNo))
                    throw new ArgumentException("Seat does not exist");

                var seat = _seats[seatNo];
                if(seat.IsBooked)
                    return false;

                seat.IsBooked = true;
                seat.BookedBy = userId;

                return true;

            }
        }

    }
}