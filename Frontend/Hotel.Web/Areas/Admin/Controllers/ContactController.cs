using AutoMapper;
using Hotel.Business.ManagerServices.Abstracts;
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
        readonly IEmailService _emailService;
        readonly IMapper _mapper;
        readonly IConfiguration _configuration;
        public ContactController(ContactApiService contactApiService, SendMessageApiService sendMessageApiService, IEmailService emailService, IMapper mapper, IConfiguration configuration)
        {
            _contactApiService = contactApiService;
            _sendMessageApiService = sendMessageApiService;
            _emailService = emailService;
            _mapper = mapper;
            _configuration = configuration;

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
            var navBarModel = new ContactNavBarVM
            {
                SendMessageCount = await _sendMessageApiService.GetSendMessageCount(),
                ContactCount = await _contactApiService.GetContactCount()
            };

            ViewBag.NavBarModel = navBarModel;

            return View(message);
        }

        public async Task<IActionResult> SendMessage()
        {
            var navBarModel = new ContactNavBarVM
            {
                SendMessageCount = await _sendMessageApiService.GetSendMessageCount(),
                ContactCount = await _contactApiService.GetContactCount()
            };

            ViewBag.NavBarModel = navBarModel;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessagePostDTO model)
        {
            var emailSettings = _configuration.GetSection("EmailSettings").Get<Dictionary<string, string>>();
            model.SenderName = "Admin";
            model.SenderEmail = emailSettings["SenderEmail"];
            model.Date = DateTime.Now;
            var sendMessage = _mapper.Map<SendMessage>(model);
            try
            {
                await _emailService.SendEmailAsync(model.RecieverEmail, model.Subject, model.Message);
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