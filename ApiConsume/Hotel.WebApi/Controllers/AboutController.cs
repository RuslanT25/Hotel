using AutoMapper;
using Hotel.Business.ManagerServices.Abstracts;
using Hotel.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAbouts()
        {
            var result = await _aboutService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var result = await _aboutService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAbout(About about)
        {
            var result = await _aboutService.AddAsync(about);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addrange")]
        public async Task<IActionResult> AddRangeAbout(List<About> abouts)
        {
            var result = await _aboutService.AddRangeAsync(abouts);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult UpdateAbout(About about)
        {
            var result = _aboutService.Update(about);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("updaterange")]
        public IActionResult UpdateRange(List<About> abouts)
        {
            var result = _aboutService.UpdateRange(abouts);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteAbout(int id)
        {
            var about = _aboutService.GetByIdAsync(id).Result.Data;
            var result = _aboutService.Delete(about);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("deleterange")]
        public IActionResult DeleteRangeAbout(List<int> ids)
        {
            var abouts = ids.Select(id => _aboutService.GetByIdAsync(id).Result.Data).ToList();
            var result = _aboutService.DeleteRange(abouts);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("destroy")]
        public IActionResult DestroyAbout(int id)
        {
            var about = _aboutService.GetByIdAsync(id).Result.Data;
            var result = _aboutService.Destroy(about);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("destroyrange")]
        public IActionResult DestroyRangeAbout(List<int> ids)
        {
            var abouts = ids.Select(x => _aboutService.GetByIdAsync(x).Result.Data).ToList();
            var result = _aboutService.DestroyRange(abouts);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
