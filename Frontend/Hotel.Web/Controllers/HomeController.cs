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
        public HomeController(AboutApiService aboutApiService, RoomApiService roomApiService)
        {
            _aboutApiService = aboutApiService;
            _roomApiService = roomApiService;
        }
        public async Task<IActionResult> Index()
        {
            List<About> abouts= await _aboutApiService.GetAllAboutsAsync();
            List<Room> rooms = await _roomApiService.GetAllRoomsAsync();
            HomeVM homeVM = new HomeVM
            {
                Abouts = abouts,
                Rooms = rooms
            };

            return View(homeVM);
        }
    }
}
