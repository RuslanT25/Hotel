using Hotel.DAL.ApplicationContext;
using Hotel.DAL.Repositories.Abstracts;
using Hotel.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAL.Repositories.Concretes
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(HotelDbContext context) : base(context)
        {
        }
    }
}
