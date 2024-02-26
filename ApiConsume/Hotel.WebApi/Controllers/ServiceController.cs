using Hotel.Business.ManagerServices.Abstracts;
using Hotel.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        readonly IServiceService _service;
        public ServiceController(IServiceService service)
        {
            _service = service;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllServices()
        {
            var result = await _service.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddService(Service service)
        {
            var result = await _service.AddAsync(service);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addrange")]
        public async Task<IActionResult> AddRangeService(List<Service> services)
        {
            var result = await _service.AddRangeAsync(services);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult UpdateService(Service service)
        {
            var result = _service.Update(service);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("updaterange")]
        public IActionResult UpdateRange(List<Service> services)
        {
            var result = _service.UpdateRange(services);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteService(int id)
        {
            var service = _service.GetByIdAsync(id).Result.Data;
            var result = _service.Delete(service);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("deleterange")]
        public IActionResult DeleteRangeService(List<int> ids)
        {
            var services = ids.Select(x => _service.GetByIdAsync(x).Result.Data).ToList();
            var result = _service.DeleteRange(services);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("destroy")]
        public IActionResult DestroyService(int id)
        {
            var service = _service.GetByIdAsync(id).Result.Data;
            var result = _service.Destroy(service);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("destroyrange")]
        public IActionResult DestroyRangeService(List<int> ids)
        {
            var services = ids.Select(x => _service.GetByIdAsync(x).Result.Data).ToList();
            var result = _service.DestroyRange(services);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
