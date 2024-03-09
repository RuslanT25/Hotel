using Hotel.Business.ManagerServices.Abstracts;
using Hotel.DAL.Repositories.Abstracts;
using Hotel.DAL.Repositories.Concretes;
using Hotel.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.ManagerServices.Concretes
{
    public class BookingManager : BaseManager<Booking>, IBookingService
    {
        readonly IBookingRepository _bookingRepository;
        public BookingManager(IBookingRepository bookingRepository) : base(bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
    }
}
