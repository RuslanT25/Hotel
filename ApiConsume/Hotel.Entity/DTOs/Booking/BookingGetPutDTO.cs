using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Entity.DTOs.Booking
{
    public class BookingGetPutDTO : BookingBaseDTO
    {
        public int Id { get; set; }
        public List<string> Guests { get; set; }
    }
}
