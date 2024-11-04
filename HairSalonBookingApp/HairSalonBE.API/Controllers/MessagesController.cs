using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Services.Interface;
using HairSalon.Core;
using HairSalon.ModelViews.Message;
using HairSalon.Services.Service;
using HairSalon.Services.SignalIR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace HairSalonBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController(IMessageService messageService) : ControllerBase
    {
        // POST: api/Messages
        [HttpPost("create")]
        public async Task<ActionResult<Message>> SendMessage([FromBody] CreateMessageViewModel message)
        {
            message.Timestamp = DateTime.UtcNow;
            var result = await messageService.AddMessageAsync(message);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MessageViewModel>> GetMessageById(string id)
        {
            var message = await messageService.GetMessageByIdAsync(id);
            
            return Ok(message);
        }
        
        [HttpGet("all")]
        public async Task<ActionResult<BasePaginatedList<MessageViewModel>>> GetAllShops(int pageNumber = 1, int pageSize = 5)
        {
            var result = await messageService.GetAllMessageAsync(pageNumber, pageSize);
            return Ok(result);
        }
     }
}
