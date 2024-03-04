using Hotel.Entity.DTOs.Room;
using Hotel.Entity.Models;

namespace Hotel.Web.ViewModels
{
    public class HomeVM
    {
        public List<About> Abouts { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
