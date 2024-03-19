using Hotel.Entity.DTOs.Booking;
using Hotel.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.ManagerServices.Abstracts
{
    public interface IBookingService : IBaseService<Booking>
    {
        public Task<bool> IsBookingAvailableAsync(Booking newBooking);
    }
}
