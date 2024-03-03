using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Entity.DTOs.Room
{
    public class RoomGetPutDTO : RoomBaseDTO
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
    }
}
