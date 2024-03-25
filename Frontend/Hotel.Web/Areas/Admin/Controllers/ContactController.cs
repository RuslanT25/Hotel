using AutoMapper;
using Hotel.Entity.DTOs.Contact.Inbox;
using Hotel.WebApi.Services.WebApiServices;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        readonly ContactApiService _contactApiService;
        readonly IMapper _mapper;
        public ContactController(ContactApiService contactApiService, IMapper mapper)
        {
            _contactApiService = contactApiService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Inbox()
        {
            var models = await _contactApiService.GetAllContactsAsync();
            var messages = _mapper.Map<List<ContactGetPutDTO>>(models);

            return View(messages);
        }
    }
}
