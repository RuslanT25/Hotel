using Castle.Components.DictionaryAdapter.Xml;
using Hotel.Business.ManagerServices.Abstracts;
using Hotel.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllRooms()
        {
            var result = await _roomService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            var result = await _roomService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddRoom(Room room)
        {
            var result = await _roomService.AddAsync(room);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addrange")]
        public async Task<IActionResult> AddRangeRoom(List<Room> rooms)
        {
            var result = await _roomService.AddRangeAsync(rooms);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult UpdateRoom(Room room)
        {
            var result = _roomService.Update(room);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("updaterange")]
        public IActionResult UpdateRange(List<Room> rooms)
        {
            var result = _roomService.UpdateRange(rooms);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteRoom(int id)
        {
            var room = _roomService.GetByIdAsync(id).Result.Data;
            var result = _roomService.Delete(room);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("deleterange")]
        public IActionResult DeleteRangeRoom(List<int> ids)
        {
            var rooms = ids.Select(id => _roomService.GetByIdAsync(id).Result.Data).ToList();
            var result = _roomService.DeleteRange(rooms);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("destroy")]
        public IActionResult DestroyRoom(int id)
        {
            var room = _roomService.GetByIdAsync(id).Result.Data;
            var result = _roomService.Destroy(room);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("destroyrange")]
        public IActionResult DestroyRangeRoom(List<int> ids)
        {
            var rooms = ids.Select(x => _roomService.GetByIdAsync(x).Result.Data).ToList();
            var result = _roomService.DestroyRange(rooms);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
