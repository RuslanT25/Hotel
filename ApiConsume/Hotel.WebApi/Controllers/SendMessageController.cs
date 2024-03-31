using AutoMapper;
using Hotel.Business.ManagerServices.Abstracts;
using Hotel.Entity.DTOs.Contact.SendMessage;
using Hotel.Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : Controller
    {
        readonly IMapper _mapper;
        readonly ISendMessageService _sendMessageService;
        public SendMessageController(ISendMessageService sendMessageService, IMapper mapper)
        {
            _sendMessageService = sendMessageService;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllSendMessages()
        {
            var result = await _sendMessageService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSendMessage(int id)
        {
            var result = await _sendMessageService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddSendMessage(SendMessagePostDTO model)
        {
            model.Date = DateTime.Now;
            var sendMessage = _mapper.Map<SendMessage>(model);
            var result = await _sendMessageService.AddAsync(sendMessage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addrange")]
        public async Task<IActionResult> AddRangeSendMessage(List<SendMessagePostDTO> models)
        {
            var sendMessages = _mapper.Map<List<SendMessage>>(models);
            var result = await _sendMessageService.AddRangeAsync(sendMessages);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult UpdateSendMessage(SendMessageGetDTO model)
        {
            var sendMessage = _mapper.Map<SendMessage>(model);
            var result = _sendMessageService.Update(sendMessage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("updaterange")]
        public IActionResult UpdateRange(List<SendMessageGetDTO> models)
        {
            var sendMessages = _mapper.Map<List<SendMessage>>(models);
            var result = _sendMessageService.UpdateRange(sendMessages);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteSendMessage(int id)
        {
            var sendMessage = _sendMessageService.GetByIdAsync(id).Result.Data;
            var result = _sendMessageService.Delete(sendMessage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("deleterange")]
        public IActionResult DeleteRangeSendMessage(List<int> ids)
        {
            var sendMessages = ids.Select(id => _sendMessageService.GetByIdAsync(id).Result.Data).ToList();
            var result = _sendMessageService.DeleteRange(sendMessages);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("destroy")]
        public IActionResult DestroySendMessage(int id)
        {
            var sendMessage = _sendMessageService.GetByIdAsync(id).Result.Data;
            var result = _sendMessageService.Destroy(sendMessage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("destroyrange")]
        public IActionResult DestroyRangeSendMessage(List<int> ids)
        {
            var sendMessages = ids.Select(x => _sendMessageService.GetByIdAsync(x).Result.Data).ToList();
            var result = _sendMessageService.DestroyRange(sendMessages);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getsendmessagecount")]
        public IActionResult GetSendMessageCount()
        {
            return Ok(_sendMessageService.GetSendMesaageCount());
        }
    }
}
