using Hotel.Entity.DTOs.Staff;
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
            var staff = await _staffApiService.GetAllStaffAsync();

            return View(staff);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(StaffPostDTO staffPost)
        {
            await _staffApiService.AddStaffAsync(staffPost);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _staffApiService.DeleteStaffAsync(id);

            return RedirectToAction("Index");
        }
    }
}
