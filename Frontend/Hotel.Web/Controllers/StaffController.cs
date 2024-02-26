using AutoMapper;
using Hotel.Entity.DTOs.Staff;
using Hotel.Entity.Models;
using Hotel.Web.Validations.Staff;
using Hotel.WebApi.Services.WebApiServices;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;

namespace Hotel.Web.Controllers
{
    public class StaffController : Controller
    {
        readonly StaffApiService _staffApiService;
        readonly StaffValidator _validator;
        readonly IMapper _mapper;
        public StaffController(StaffApiService staffApiService, StaffValidator validations, IMapper mapper)
        {
            _staffApiService = staffApiService;
            _validator = validations;
            _mapper = mapper;
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
        public async Task<IActionResult> Add(StaffPostDTO model)
        {
            var staff=_mapper.Map<Staff>(model);
            var result = _validator.Validate(model);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View();
            }

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
        public async Task<IActionResult> Update(StaffGetPutDTO model) 
        {
            var staff =_mapper.Map<Staff>(model);
            //var result = _validator.Validate(model);
            //if (!result.IsValid)
            //{
            //    foreach (var error in result.Errors)
            //    {
            //        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            //    }

            //    return View();
            //}

            await _staffApiService.UpdateStaffAsync(staff);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _staffApiService.DeleteStaffAsync(id);

            return RedirectToAction("Index");
        }
    }
}
