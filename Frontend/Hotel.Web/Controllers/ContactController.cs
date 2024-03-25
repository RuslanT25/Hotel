using AutoMapper;
using Hotel.Entity.DTOs.Contact.Inbox;
using Hotel.Entity.DTOs.Subscribe;
using Hotel.Entity.Models;
using Hotel.Web.Validations.Subscribe;
using Hotel.Web.ViewModels;
using Hotel.WebApi.Services.WebApiServices;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hotel.Web.Controllers
{
    public class ContactController : Controller
    {
        readonly SubscribeApiService _subscribeApiService;
        readonly SubscribeValidator _subscribeValidator;
        readonly ContactApiService _contactApiService;
        readonly IMapper _mapper;
        public ContactController(SubscribeApiService subscribeApiService, SubscribeValidator subscribeValidator, IMapper mapper, ContactApiService contactApiService)
        {
            _subscribeApiService = subscribeApiService;
            _subscribeValidator = subscribeValidator;
            _mapper = mapper;
            _contactApiService = contactApiService;
        }

        public IActionResult Index()
        {
            ContactVM contactVM = new()
            {
                Subscribe = new SubscribePostDTO(),
                Contact = new ContactPostDTO()
            };

            return View(contactVM);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(ContactPostDTO model)
        {
            model.Date= DateTime.Now;
            var contact = _mapper.Map<Contact>(model);
            await _contactApiService.AddContactAsync(contact);

            return RedirectToAction("Index", "Home");
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
