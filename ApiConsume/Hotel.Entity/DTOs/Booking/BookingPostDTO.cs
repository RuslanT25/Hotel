﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Entity.DTOs.Booking
{
    public class BookingPostDTO : BookingBaseDTO
    {
        public List<int>? GuestsIds { get; set; }
    }
}
