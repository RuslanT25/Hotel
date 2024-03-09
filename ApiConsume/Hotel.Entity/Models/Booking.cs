using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Entity.Models
{
    public class Booking : BaseEntity
    {
        public string FullName { get; set; }
        public string Mail { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime CheckOut { get; set; }
        public int AdultCount { get; set; }
        public int Children { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public string SpecialRequest { get; set; }
        public BookingStatus Status { get; set; }
    }
    public enum BookingStatus
    {
        Pending,
        Accepted,
        Denied
    }
}
