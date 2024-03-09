using AutoMapper;
using Hotel.Entity.DTOs.Subscribe;
using Hotel.Entity.Models;
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
        readonly SubscribeValidator _subscribeValidator;
        readonly IMapper _mapper;
        public BookingController(SubscribeApiService subscribeApiService, SubscribeValidator validationRules, IMapper mapper)
        {
            _subscribeApiService = subscribeApiService;
            _subscribeValidator = validationRules;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            BookingVM booking = new()
            {
                Subscribe = new SubscribePostDTO()
            };

            return View(booking);
        }

        [HttpGet]
        public async Task<IActionResult> Subscribe()
        {
            return View();
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
