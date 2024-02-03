using Hotel.Business.ManagerServices.Abstracts;
using Hotel.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        readonly ISubscribeService _subscribeService;
        public SubscribeController(ISubscribeService service)
        {
            _subscribeService = service;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllSubscribes()
        {
            var result = await _subscribeService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscribe(int id)
        {
            var result = await _subscribeService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddSubscribe(Subscribe subscribe)
        {
            var result = await _subscribeService.AddAsync(subscribe);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addrange")]
        public async Task<IActionResult> AddRangeSubscribe(List<Subscribe> subscribes)
        {
            var result = await _subscribeService.AddRangeAsync(subscribes);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteSubscribe(int id)
        {
            var subscribe = _subscribeService.GetByIdAsync(id).Result.Data;
            var result = _subscribeService.Delete(subscribe);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("deleterange")]
        public IActionResult DeleteRangeSubscribe(List<int> ids)
        {
            var subscribes = ids.Select(id => _subscribeService.GetByIdAsync(id).Result.Data).ToList();
            var result = _subscribeService.DeleteRange(subscribes);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("destroy")]
        public IActionResult DestroySubscribe(int id)
        {
            var subscribe = _subscribeService.GetByIdAsync(id).Result.Data;
            var result = _subscribeService.Destroy(subscribe);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("destroyrange")]
        public IActionResult DestroyRangeSubscribe(List<int> ids)
        {
            var subscribes = ids.Select(x => _subscribeService.GetByIdAsync(x).Result.Data).ToList();
            var result = _subscribeService.DestroyRange(subscribes);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
