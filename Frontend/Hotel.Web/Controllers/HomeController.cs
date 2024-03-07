using AutoMapper;
using Hotel.Entity.DTOs.Room;
using Hotel.Entity.DTOs.Subscribe;
using Hotel.Entity.Models;
using Hotel.Web.Validations.Subscribe;
using Hotel.Web.ViewModels;
using Hotel.WebApi.Services.WebApiServices;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hotel.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly AboutApiService _aboutApiService;
        readonly RoomApiService _roomApiService;
        readonly ServiceApiService _serviceApiService;
        readonly TestimonialApiService _testimonialApiService;
        readonly StaffApiService _staffApiService;
        readonly SubscribeApiService _subscribeApiService;
        readonly IMapper _mapper;
        readonly SubscribeValidator _subscribeValidator;
        public HomeController(AboutApiService aboutApiService, RoomApiService roomApiService, ServiceApiService serviceApiService, TestimonialApiService testimonialApiService, StaffApiService staffApiService, SubscribeApiService subscribeApiService, IMapper mapper, SubscribeValidator validationRules)
        {
            _aboutApiService = aboutApiService;
            _roomApiService = roomApiService;
            _serviceApiService = serviceApiService;
            _testimonialApiService = testimonialApiService;
            _staffApiService = staffApiService;
            _subscribeApiService = subscribeApiService;
            _mapper = mapper;
            _subscribeValidator = validationRules;

        }
        public async Task<IActionResult> Index()
        {
            List<About> abouts= await _aboutApiService.GetAllAboutsAsync();
            List<Room> rooms = await _roomApiService.GetAllRoomsAsync();
            List<Service> services = await _serviceApiService.GetAllServices();
            List<Testimonial> testimonials = await _testimonialApiService.GetAllTestimonialsAsync();
            List<Staff> staff = await _staffApiService.GetAllStaffAsync();
            HomeVM homeVM = new()
            {
                Abouts = abouts,
                Rooms = rooms,
                Services = services,
                Testimonials = testimonials,
                Staff = staff,
                Subscribe = new SubscribePostDTO()
            };

            return View(homeVM);
        }

        [HttpGet]
        public async Task<IActionResult> Subscribe()
        {
            return View();
        }

        [HttpPost]
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
