using Hotel.Entity.DTOs.Booking;
using Hotel.Entity.DTOs.Subscribe;
using Hotel.Entity.Models;

namespace Hotel.Web.ViewModels
{
    public class BookingVM
    {
        public List<Room> Rooms { get; set; }
        public SubscribePostDTO Subscribe {  get; set; }
        public BookingPostDTO Booking { get; set; }
    }
}
