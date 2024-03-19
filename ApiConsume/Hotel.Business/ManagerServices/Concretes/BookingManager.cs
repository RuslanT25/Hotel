using Hotel.Business.ManagerServices.Abstracts;
using Hotel.Business.Results;
using Hotel.DAL.Repositories.Abstracts;
using Hotel.DAL.Repositories.Concretes;
using Hotel.Entity.DTOs.Booking;
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

        public async Task<bool> IsBookingAvailableAsync(Booking newBooking)
        {
            var bookings = await _bookingRepository.GetBookingsByRoomIdAsync(newBooking.RoomId);
            return !bookings.Any(b => b.Checkin < newBooking.CheckOut && b.CheckOut > newBooking.Checkin);
        }

        public override async Task<Result> AddAsync(Booking booking)
        {
            if (!await IsBookingAvailableAsync(booking))
            {
                return new ErrorResult("The room is already booked during this period.");
            }

            return await base.AddAsync(booking);
        }

    }
}
