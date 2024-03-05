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
        public HomeController(AboutApiService aboutApiService, RoomApiService roomApiService, ServiceApiService serviceApiService)
        {
            _aboutApiService = aboutApiService;
            _roomApiService = roomApiService;
            _serviceApiService = serviceApiService;

        }
        public async Task<IActionResult> Index()
        {
            List<About> abouts= await _aboutApiService.GetAllAboutsAsync();
            List<Room> rooms = await _roomApiService.GetAllRoomsAsync();
            List<Service> services = await _serviceApiService.GetAllServices();
            HomeVM homeVM = new()
            {
                Abouts = abouts,
                Rooms = rooms,
                Services = services
            };

            return View(homeVM);
        }
    }
}
