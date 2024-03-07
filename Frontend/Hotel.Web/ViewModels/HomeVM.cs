using Hotel.Entity.DTOs.Room;
using Hotel.Entity.DTOs.Subscribe;
using Hotel.Entity.Models;

namespace Hotel.Web.ViewModels
{
    public class HomeVM
    {
        public List<About> Abouts { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Service> Services { get; set; }
        public List<Testimonial> Testimonials { get; set;}
        public List<Staff> Staff { get; set; }
        public SubscribePostDTO Subscribe { get; set; }
    }
}
