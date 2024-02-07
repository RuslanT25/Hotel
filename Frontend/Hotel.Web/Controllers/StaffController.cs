using Hotel.Entity.Models;
using Hotel.WebApi.Services.WebApiServices;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;

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
        public async Task<IActionResult> Add(Staff staff)
        {
            await _staffApiService.AddStaffAsync(staff);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var staff = await _staffApiService.GetStaffByIdAsync(id);

            return View(staff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Staff model) 
        {
            await _staffApiService.UpdateStaffAsync(model);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _staffApiService.DeleteStaffAsync(id);

            return RedirectToAction("Index");
        }
    }
}
