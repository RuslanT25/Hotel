using AutoMapper;
using Hotel.Business.ManagerServices.Abstracts;
using Hotel.Entity.DTOs.Contact.Inbox;
using Hotel.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly IContactService _contactService;
        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllContacts()
        {
            var result = await _contactService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var result = await _contactService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddContact(ContactPostDTO model)
        {
            model.Date = DateTime.Now;
            var contact = _mapper.Map<Contact>(model);
            var result = await _contactService.AddAsync(contact);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addrange")]
        public async Task<IActionResult> AddRangeContact(List<ContactPostDTO> models)
        {
            var contacts = _mapper.Map<List<Contact>>(models);
            var result = await _contactService.AddRangeAsync(contacts);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult UpdateContact(ContactGetDTO model)
        {
            var contact = _mapper.Map<Contact>(model);
            var result = _contactService.Update(contact);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("updaterange")]
        public IActionResult UpdateRange(List<ContactGetDTO> models)
        {
            var contacts = _mapper.Map<List<Contact>>(models);
            var result = _contactService.UpdateRange(contacts);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteContact(int id)
        {
            var contact = _contactService.GetByIdAsync(id).Result.Data;
            var result = _contactService.Delete(contact);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("deleterange")]
        public IActionResult DeleteRangeContact(List<int> ids)
        {
            var contacts = ids.Select(id => _contactService.GetByIdAsync(id).Result.Data).ToList();
            var result = _contactService.DeleteRange(contacts);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("destroy")]
        public IActionResult DestroyContact(int id)
        {
            var contact = _contactService.GetByIdAsync(id).Result.Data;
            var result = _contactService.Destroy(contact);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("destroyrange")]
        public IActionResult DestroyRangeContact(List<int> ids)
        {
            var contacts = ids.Select(x => _contactService.GetByIdAsync(x).Result.Data).ToList();
            var result = _contactService.DestroyRange(contacts);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}