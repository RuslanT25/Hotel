using AutoMapper;
using Hotel.Entity.DTOs.About;
using Hotel.Entity.Models;
using Hotel.Web.Validations.About;
using Hotel.WebApi.Services.WebApiServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AboutController : Controller
    {
        readonly AboutApiService _aboutApiService;
        readonly AboutValidator _validator;
        readonly IMapper _mapper;
        public AboutController(AboutApiService aboutApiService, AboutValidator validations, IMapper mapper)
        {
            _aboutApiService = aboutApiService;
            _validator = validations;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var about = await _aboutApiService.GetAllAboutsAsync();

            return View(about);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AboutPostDTO model)
        {
            var about = _mapper.Map<About>(model);
            var result = await _validator.ValidateAsync(model);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View();
            }

            await _aboutApiService.AddAboutAsync(about);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AboutPutDTO model)
        {
            var about = _mapper.Map<About>(model);
            var result = _validator.Validate(model);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View();
            }

            await _aboutApiService.UpdateAboutAsync(about);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _aboutApiService.DeleteAboutAsync(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Destroy(int id)
        {
            await _aboutApiService.DestroyAboutAsync(id);

            return RedirectToAction("Index");
        }
    }
}
