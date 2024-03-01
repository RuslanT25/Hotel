using AutoMapper;
using Hotel.Business.ManagerServices.Abstracts;
using Hotel.Entity.DTOs.About;
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
        readonly IMapper _mapper;
        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
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
        public async Task<IActionResult> AddAbout(AboutPostDTO model)
        {
            var about = _mapper.Map<About>(model);
            var result = await _aboutService.AddAsync(about);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addrange")]
        public async Task<IActionResult> AddRangeAbout(List<AboutPostDTO> models)
        {
            var abouts = _mapper.Map<List<About>>(models);
            var result = await _aboutService.AddRangeAsync(abouts);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult UpdateAbout(AboutPutDTO model)
        {
            var about = _mapper.Map<About>(model);
            var result = _aboutService.Update(about);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("updaterange")]
        public IActionResult UpdateRange(List<AboutPutDTO> models)
        {
            var abouts = _mapper.Map<List<About>>(models);
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
