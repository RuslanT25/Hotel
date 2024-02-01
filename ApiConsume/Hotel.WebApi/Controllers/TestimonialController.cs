using Hotel.Business.ManagerServices.Abstracts;
using Hotel.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        readonly ITestimonialService _testimonialService;
        public TestimonialController(ITestimonialService service)
        {
            _testimonialService = service;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllTestimonials()
        {
            var result = await _testimonialService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            var result = await _testimonialService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTestimonial(Testimonial testimonial)
        {
            var result = await _testimonialService.AddAsync(testimonial);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addrange")]
        public async Task<IActionResult> AddRangeTestimonial(List<Testimonial> testimonials)
        {
            var result = await _testimonialService.AddRangeAsync(testimonials);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteTestimonial(int id)
        {
            var testimonial = _testimonialService.GetByIdAsync(id).Result.Data;
            var result = _testimonialService.Delete(testimonial);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("deleterange")]
        public IActionResult DeleteRangeTestimonial(List<int> ids)
        {
            var testimonials = ids.Select(id => _testimonialService.GetByIdAsync(id).Result.Data).ToList();
            var result = _testimonialService.DeleteRange(testimonials);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("destroy")]
        public IActionResult DestroyTestimonial(int id)
        {
            var testimonial = _testimonialService.GetByIdAsync(id).Result.Data;
            var result = _testimonialService.Destroy(testimonial);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("destroyrange")]
        public IActionResult DestroyRangeTestimonial(List<int> ids)
        {
            var testimonials = ids.Select(x => _testimonialService.GetByIdAsync(x).Result.Data).ToList();
            var result = _testimonialService.DestroyRange(testimonials);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
