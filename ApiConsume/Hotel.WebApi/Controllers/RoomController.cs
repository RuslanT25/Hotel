﻿using AutoMapper;
using Castle.Components.DictionaryAdapter.Xml;
using Hotel.Business.ManagerServices.Abstracts;
using Hotel.Entity.DTOs.Room;
using Hotel.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        readonly IRoomService _roomService;
        readonly IMapper _mapper;
        public RoomController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
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
        public async Task<IActionResult> AddRoom([FromForm] RoomPostDTO model)
        {
            var room = _mapper.Map<Room>(model);
            var result = await _roomService.AddRoomWithImageAsync(room, model.ImageFile);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addrange")]
        public async Task<IActionResult> AddRangeRoom(List<RoomPostDTO> model)
        {
            var rooms=_mapper.Map<List<Room>>(model);
            var result = await _roomService.AddRangeAsync(rooms);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult UpdateRoom(RoomGetPutDTO model)
        {
            var room = _mapper.Map<Room>(model);
            var result = _roomService.Update(room);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("updaterange")]
        public IActionResult UpdateRange(List<RoomGetPutDTO> models)
        {
            var rooms = _mapper.Map<List<Room>>(models);
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
