using Hotel.Entity.Models;
using Hotel.Web.ViewModels;
using Hotel.WebApi.Services.WebApiServices;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly AboutApiService _aboutApiService;
        public HomeController(AboutApiService aboutApiService)
        {
            _aboutApiService = aboutApiService;
        }
        public async Task<IActionResult> Index()
        {
            List<About> abouts= await _aboutApiService.GetAllAboutsAsync();
            HomeVM homeVM = new HomeVM
            {
                Abouts = abouts
            };

            return View(homeVM);
        }
    }
}
