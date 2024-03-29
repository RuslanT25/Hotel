﻿using Hotel.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAL.Repositories.Abstracts
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        public Task<List<Booking>> GetBookingsByRoomIdAsync(int roomId);
    }
}
