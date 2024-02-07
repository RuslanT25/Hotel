using Hotel.Entity.Models;
using Hotel.WebApi.Services.WebApiServices;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class TestimonialController : Controller
    {
        readonly TestimonialApiService _testimonialApiService;
        public TestimonialController(TestimonialApiService testimonialApiService)
        {
            _testimonialApiService = testimonialApiService;
        }
        public async Task<IActionResult> Index()
        {
            var testimonials = await _testimonialApiService.GetAllTestimonialsAsync();

            return View(testimonials);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Testimonial testimonial)
        {
            await _testimonialApiService.AddTestimonialAsync(testimonial);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var testimonial = await _testimonialApiService.GetTestimonialByIdAsync(id);

            return View(testimonial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Testimonial model)
        {
            await _testimonialApiService.UpdateTestimonialAsync(model);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _testimonialApiService.DeleteTestimonialAsync(id);

            return RedirectToAction("Index");
        }
    }
}
