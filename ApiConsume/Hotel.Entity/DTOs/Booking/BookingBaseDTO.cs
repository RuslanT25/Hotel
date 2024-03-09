using Hotel.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Entity.DTOs.Booking
{
    public class BookingBaseDTO
    {
        public string FullName { get; set; }
        public string Mail { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime CheckOut { get; set; }
        public int AdultCount { get; set; }
        public int Children { get; set; }
        public int RoomId { get; set; }
        public virtual Models.Room Room { get; set; }
        public string SpecialRequest { get; set; }
        public BookingStatus Status { get; set; }
    }
}
