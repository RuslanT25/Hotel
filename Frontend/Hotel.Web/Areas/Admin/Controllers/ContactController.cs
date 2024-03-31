using AutoMapper;
using Hotel.Entity.DTOs.Contact.Inbox;
using Hotel.Entity.DTOs.Contact.SendMessage;
using Hotel.Entity.Models;
using Hotel.Web.ViewModels;
using Hotel.WebApi.Services.WebApiServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ContactController : Controller
    {
        readonly ContactApiService _contactApiService;
        readonly SendMessageApiService _sendMessageApiService;
        readonly IMapper _mapper;
        public ContactController(ContactApiService contactApiService, SendMessageApiService sendMessageApiService, IMapper mapper)
        {
            _contactApiService = contactApiService;
            _sendMessageApiService = sendMessageApiService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Inbox()
        {
            var models = await _contactApiService.GetAllContactsAsync();
            var messages = _mapper.Map<List<ContactGetDTO>>(models);
            var navBarModel = new ContactNavBarVM
            {
                ContactCount = await _contactApiService.GetContactCount(),
                SendMessageCount = await _sendMessageApiService.GetSendMessageCount()
            };

            ViewBag.NavBarModel = navBarModel;

            return View(messages);
        }

        public async Task<IActionResult> InboxMessageDetails(int id)
        {
            var model = await _contactApiService.GetContactByIdAsync(id);
            var message = _mapper.Map<ContactGetDTO>(model);

            return View(message);
        }

        public async Task<IActionResult> SendBox()
        {
            var models = await _sendMessageApiService.GetAllSendMessagesAsync();
            var messages = _mapper.Map<List<SendMessageGetDTO>>(models);
            var navBarModel = new ContactNavBarVM
            {
                SendMessageCount = await _sendMessageApiService.GetSendMessageCount(),
                ContactCount = await _contactApiService.GetContactCount()
            };

            ViewBag.NavBarModel = navBarModel;

            return View(messages);
        }

        public async Task<IActionResult> SendboxMessageDetails(int id)
        {
            var model = await _sendMessageApiService.GetSendMessageByIdAsync(id);
            var message = _mapper.Map<SendMessageGetDTO>(model);

            return View(message);
        }

        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessagePostDTO model)
        {
            model.SenderName = "Admin";
            model.SenderEmail = "tagizaderuslan25@gmail.com";
            model.Date = DateTime.Now;
            var sendMessage = _mapper.Map<SendMessage>(model);
            try
            {
                await _sendMessageApiService.AddSendMessageAsync(sendMessage);
                return RedirectToAction("SendBox");
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
