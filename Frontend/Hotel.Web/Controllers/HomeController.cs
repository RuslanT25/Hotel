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
        readonly StaffApiService _staffApiService;
        public HomeController(AboutApiService aboutApiService, RoomApiService roomApiService, ServiceApiService serviceApiService, TestimonialApiService testimonialApiService, StaffApiService staffApiService)
        {
            _aboutApiService = aboutApiService;
            _roomApiService = roomApiService;
            _serviceApiService = serviceApiService;
            _testimonialApiService = testimonialApiService;
            _staffApiService = staffApiService;

        }
        public async Task<IActionResult> Index()
        {
            List<About> abouts= await _aboutApiService.GetAllAboutsAsync();
            List<Room> rooms = await _roomApiService.GetAllRoomsAsync();
            List<Service> services = await _serviceApiService.GetAllServices();
            List<Testimonial> testimonials = await _testimonialApiService.GetAllTestimonialsAsync();
            List<Staff> staff = await _staffApiService.GetAllStaffAsync();
            HomeVM homeVM = new()
            {
                Abouts = abouts,
                Rooms = rooms,
                Services = services,
                Testimonials = testimonials,
                Staff = staff
            };

            return View(homeVM);
        }
    }
}
