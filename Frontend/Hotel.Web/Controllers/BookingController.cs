using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
