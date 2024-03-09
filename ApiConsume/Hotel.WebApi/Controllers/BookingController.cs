using AutoMapper;
using Hotel.Business.ManagerServices.Abstracts;
using Hotel.Entity.DTOs.Booking;
using Hotel.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        readonly IBookingService _bookingService;
        readonly IMapper _mapper;
        public BookingController(IBookingService service, IMapper mapper)
        {
            _bookingService = service;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllBookings()
        {
            var result = await _bookingService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var result = await _bookingService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddBooking(BookingPostDTO model)
        {
            var booking = _mapper.Map<Booking>(model);
            var result = await _bookingService.AddAsync(booking);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addrange")]
        public async Task<IActionResult> AddRangeBooking(List<BookingPostDTO> model)
        {
            var bookings = _mapper.Map<List<Booking>>(model);
            var result = await _bookingService.AddRangeAsync(bookings);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult UpdateBooking(Booking booking)
        {
            var result = _bookingService.Update(booking);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("updaterange")]
        public IActionResult UpdateRange(List<Booking> bookings)
        {
            var result = _bookingService.UpdateRange(bookings);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteBooking(int id)
        {
            var booking = _bookingService.GetByIdAsync(id).Result.Data;
            var result = _bookingService.Delete(booking);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("deleterange")]
        public IActionResult DeleteRangeBooking(List<int> ids)
        {
            var bookings = ids.Select(id => _bookingService.GetByIdAsync(id).Result.Data).ToList();
            var result = _bookingService.DeleteRange(bookings);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("destroy")]
        public IActionResult DestroyBooking(int id)
        {
            var booking = _bookingService.GetByIdAsync(id).Result.Data;
            var result = _bookingService.Destroy(booking);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("destroyrange")]
        public IActionResult DestroyRangeBooking(List<int> ids)
        {
            var bookings = ids.Select(x => _bookingService.GetByIdAsync(x).Result.Data).ToList();
            var result = _bookingService.DestroyRange(bookings);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
