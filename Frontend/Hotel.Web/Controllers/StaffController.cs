using Hotel.WebApi.Services.WebApiServices;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class StaffController : Controller
    {
        readonly StaffApiService _staffApiService;
        public StaffController(StaffApiService staffApiService)
        {
            _staffApiService = staffApiService;
        }
        public async Task<IActionResult> Index()
        {
            var staff = await _staffApiService.GetAllStaff();

            return View(staff);
        }
    }
}
