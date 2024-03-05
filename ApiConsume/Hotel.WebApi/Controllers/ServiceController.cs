using AutoMapper;
using Hotel.Business.ManagerServices.Abstracts;
using Hotel.Entity.DTOs.Service;
using Hotel.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        readonly IServiceService _serviceService;
        readonly IMapper _mapper;
        public ServiceController(IServiceService serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllServices()
        {
            var result = await _serviceService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var result = await _serviceService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddService(ServicePostDTO model)
        {
            var service = _mapper.Map<Service>(model);
            var result = await _serviceService.AddAsync(service);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addrange")]
        public async Task<IActionResult> AddRangeService(List<ServicePostDTO> model)
        {
            var services = _mapper.Map<List<Service>>(model);
            var result = await _serviceService.AddRangeAsync(services);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult UpdateService(ServiceGetPutDTO model)
        {
            var service = _mapper.Map<Service>(model);
            var result = _serviceService.Update(service);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("updaterange")]
        public IActionResult UpdateRange(List<ServiceGetPutDTO> models)
        {
            var services = _mapper.Map<List<Service>>(models);
            var result = _serviceService.UpdateRange(services);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteService(int id)
        {
            var service = _serviceService.GetByIdAsync(id).Result.Data;
            var result = _serviceService.Delete(service);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("deleterange")]
        public IActionResult DeleteRangeService(List<int> ids)
        {
            var services = ids.Select(id => _serviceService.GetByIdAsync(id).Result.Data).ToList();
            var result = _serviceService.DeleteRange(services);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("destroy")]
        public IActionResult DestroyService(int id)
        {
            var service = _serviceService.GetByIdAsync(id).Result.Data;
            var result = _serviceService.Destroy(service);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("destroyrange")]
        public IActionResult DestroyRangeService(List<int> ids)
        {
            var services = ids.Select(x => _serviceService.GetByIdAsync(x).Result.Data).ToList();
            var result = _serviceService.DestroyRange(services);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
