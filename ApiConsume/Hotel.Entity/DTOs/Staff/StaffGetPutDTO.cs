using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Entity.DTOs.Staff
{
    public class StaffGetPutDTO : StaffBaseDTO
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
    }
}
