using AutoMapper;
using Hotel.Entity.DTOs.Testimonial;
using Hotel.Entity.Models;
using Hotel.Web.Validations.Testimonial;
using Hotel.WebApi.Services.WebApiServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TestimonialController : Controller
    {
        readonly TestimonialApiService _testimonialApiService;
        readonly TestimonialValidator _validator;
        readonly IMapper _mapper;
        public TestimonialController(TestimonialApiService testimonialApiService, TestimonialValidator validations, IMapper mapper)
        {
            _testimonialApiService = testimonialApiService;
            _validator = validations;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var testimonials = await _testimonialApiService.GetAllTestimonialsAsync();
            var testimonialDTOs = _mapper.Map<List<TestimonialGetPutDTO>>(testimonials);

            return View(testimonialDTOs);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(TestimonialPostDTO model)
        {
            var testimonial = _mapper.Map<Testimonial>(model);
            var result = _validator.Validate(model);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View();
            }

            await _testimonialApiService.AddTestimonialAsync(testimonial, model.ImageFile);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(TestimonialGetPutDTO model)
        {
            var testimonial = _mapper.Map<Testimonial>(model);
            var result = _validator.Validate(model);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View();
            }

            await _testimonialApiService.UpdateTestimonialAsync(testimonial);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _testimonialApiService.DeleteTestimonialAsync(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Destroy(int id)
        {
            await _testimonialApiService.DestroyTestimonialAsync(id);

            return RedirectToAction("Index");
        }
    }
}
