using AutoMapper;
using Hotel.Business.ManagerServices.Abstracts;
using Hotel.Entity.DTOs.Staff;
using Hotel.Entity.DTOs.Staff;
using Hotel.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        readonly IStaffService _staffService;
        readonly IMapper _mapper;
        public StaffController(IStaffService staffService, IMapper mapper)
        {
            _staffService = staffService;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllStaff()
        {
            var result = await _staffService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaff(int id)
        {
            var result = await _staffService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddStaff([FromForm] StaffPostDTO model)
        {
            var staff = _mapper.Map<Staff>(model);
            var result = await _staffService.AddStaffWithImageAsync(staff, model.ImageFile);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addrange")]
        public async Task<IActionResult> AddRangeStaff(List<StaffPostDTO> model)
        {
            var staff = _mapper.Map<List<Staff>>(model);
            var result = await _staffService.AddRangeAsync(staff);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult UpdateStaff(StaffGetPutDTO model)
        {
            var staff = _mapper.Map<Staff>(model);
            var result = _staffService.Update(staff);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("updaterange")]
        public IActionResult UpdateRange(List<StaffGetPutDTO> models)
        {
            var staff = _mapper.Map<List<Staff>>(models);
            var result = _staffService.UpdateRange(staff);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteStaff(int id)
        {
            var staff = _staffService.GetByIdAsync(id).Result.Data;
            var result = _staffService.Delete(staff);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("deleterange")]
        public IActionResult DeleteRangeStaff(List<int> ids)
        {
            var staff = ids.Select(id => _staffService.GetByIdAsync(id).Result.Data).ToList();
            var result = _staffService.DeleteRange(staff);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("destroy")]
        public IActionResult DestroyStaff(int id)
        {
            var staff = _staffService.GetByIdAsync(id).Result.Data;
            var result = _staffService.Destroy(staff);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("destroyrange")]
        public IActionResult DestroyRangeStaff(List<int> ids)
        {
            var staff = ids.Select(x => _staffService.GetByIdAsync(x).Result.Data).ToList();
            var result = _staffService.DestroyRange(staff);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
