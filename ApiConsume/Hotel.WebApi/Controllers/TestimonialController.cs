using AutoMapper;
using Hotel.Business.ManagerServices.Abstracts;
using Hotel.Entity.DTOs.Testimonial;
using Hotel.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        readonly ITestimonialService _testimonialService;
        readonly IMapper _mapper;
        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
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
        public async Task<IActionResult> AddTestimonial([FromForm] TestimonialPostDTO model)
        {
            var testimonial = _mapper.Map<Testimonial>(model);
            var result = await _testimonialService.AddTestimonialWithImageAsync(testimonial, model.ImageFile);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addrange")]
        public async Task<IActionResult> AddRangeTestimonial(List<TestimonialPostDTO> model)
        {
            var testimonials = _mapper.Map<List<Testimonial>>(model);
            var result = await _testimonialService.AddRangeAsync(testimonials);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult UpdateTestimonial(TestimonialGetPutDTO model)
        {
            var testimonial = _mapper.Map<Testimonial>(model);
            var result = _testimonialService.Update(testimonial);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("updaterange")]
        public IActionResult UpdateRange(List<TestimonialGetPutDTO> models)
        {
            var testimonials = _mapper.Map<List<Testimonial>>(models);
            var result = _testimonialService.UpdateRange(testimonials);
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
