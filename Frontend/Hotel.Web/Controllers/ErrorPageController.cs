using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404(int code)
        {
            return View();
        }

        public IActionResult Error400(int code)
        {
            return View();
        }

        public IActionResult Error403(int code)
        {
            return View();
        }

        public IActionResult Error500(int code)
        {
            return View();
        }

        public IActionResult Error503(int code)
        {
            return View();
        }
    }
}
