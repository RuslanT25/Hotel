using AutoMapper;
using Hotel.Entity.DTOs.Booking;
using Hotel.Entity.DTOs.Subscribe;
using Hotel.Entity.Models;
using Hotel.Web.Validations.Booking;
using Hotel.Web.Validations.Subscribe;
using Hotel.Web.ViewModels;
using Hotel.WebApi.Services.WebApiServices;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hotel.Web.Controllers
{
    public class BookingController : Controller
    {
        readonly SubscribeApiService _subscribeApiService;
        readonly RoomApiService _roomApiService;
        readonly BookingApiService _bookingApiService;
        readonly SubscribeValidator _subscribeValidator;
        readonly BookingValidator _bookingValidator;
        readonly IMapper _mapper;
        public BookingController(SubscribeApiService subscribeApiService, SubscribeValidator validationRules, BookingApiService bookingApiService,IMapper mapper, BookingValidator bookingValidator, RoomApiService roomApiService)
        {
            _subscribeApiService = subscribeApiService;
            _subscribeValidator = validationRules;
            _bookingApiService = bookingApiService;
            _mapper = mapper;
            _bookingValidator = bookingValidator;
            _roomApiService = roomApiService;
        }
        public async Task<IActionResult> Index()
        {
            var rooms = await _roomApiService.GetAllRoomsAsync();
            BookingVM booking = new()
            {
                Rooms = rooms,
                Subscribe = new SubscribePostDTO(),
                Booking = new BookingPostDTO()
            };

            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookingVM model)
        {
            model.Booking.Status = BookingStatus.Pending;
            var booking = _mapper.Map<Booking>(model.Booking);
            var result = await _bookingValidator.ValidateAsync(model.Booking);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                model.Rooms = await _roomApiService.GetAllRoomsAsync();

                return View(model);
            }
            model.Rooms = await _roomApiService.GetAllRoomsAsync();

            await _bookingApiService.AddBookingAsync(booking);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribePostDTO model)
        {
            var subscribe = _mapper.Map<Subscribe>(model);
            var result = await _subscribeValidator.ValidateAsync(model);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View();
            }

            try
            {
                await _subscribeApiService.AddSubscribeAsync(subscribe);
                return RedirectToAction("Index");
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
            {
                TempData["ErrorMessage"] = "This e-mail already subscribed.";
                return RedirectToAction("Index");
            }
        }
    }
}
