﻿using AutoMapper;
using Hotel.Entity.DTOs.Contact.Inbox;
using Hotel.Entity.DTOs.Contact.SendMessage;
using Hotel.Entity.Models;
using Hotel.WebApi.Services.WebApiServices;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            var messages = _mapper.Map<List<ContactGetPutDTO>>(models);

            return View(messages);
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
                return RedirectToAction("Inbox");
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
