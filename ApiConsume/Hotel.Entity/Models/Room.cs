using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Entity.Models
{
    public class Room : BaseEntity
    {
        public string RoomNumber { get; set; }
        public string CoverImage { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int BedCount { get; set; }
        public int BathCount { get; set; }
        public string Wifi { get; set; }
    }
}
