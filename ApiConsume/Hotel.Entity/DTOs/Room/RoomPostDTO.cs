﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Entity.DTOs.Room
{
    public class RoomPostDTO : RoomBaseDTO
    {
        public IFormFile ImageFile { get; set; }
    }
}
