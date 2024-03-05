using Hotel.Entity.DTOs.Room;
using Hotel.Entity.Models;
using Hotel.Web.ViewModels;
using Hotel.WebApi.Services.WebApiServices;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly AboutApiService _aboutApiService;
        readonly RoomApiService _roomApiService;
        readonly ServiceApiService _serviceApiService;
        readonly TestimonialApiService _testimonialApiService;
        public HomeController(AboutApiService aboutApiService, RoomApiService roomApiService, ServiceApiService serviceApiService, TestimonialApiService testimonialApiService)
        {
            _aboutApiService = aboutApiService;
            _roomApiService = roomApiService;
            _serviceApiService = serviceApiService;
            _testimonialApiService = testimonialApiService;
        }
        public async Task<IActionResult> Index()
        {
            List<About> abouts= await _aboutApiService.GetAllAboutsAsync();
            List<Room> rooms = await _roomApiService.GetAllRoomsAsync();
            List<Service> services = await _serviceApiService.GetAllServices();
            List<Testimonial> testimonials = await _testimonialApiService.GetAllTestimonialsAsync();
            HomeVM homeVM = new()
            {
                Abouts = abouts,
                Rooms = rooms,
                Services = services,
                Testimonials = testimonials
            };

            return View(homeVM);
        }
    }
}
