using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
