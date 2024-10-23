using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Services.Interface;
using HairSalon.ModelViews.Message;
using HairSalon.Services.Service;
using HairSalon.Services.SignalIR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace HairSalonBE.API.Controllers
{
    public class MessagesController : ControllerBase
    {
        private readonly IHubContext<MessageHub> _hubContext;
        private readonly IMessageService _messageService;

        public MessagesController( IHubContext<MessageHub> hubContext, IMessageService messageService)
        {
            _hubContext = hubContext;
            _messageService = messageService;
        }

        // POST: api/Messages
        [HttpPost]
        public async Task<ActionResult<Message>> SendMessage([FromBody] CreateMessageViewModel message)
        {
            message.Timestamp = DateTime.UtcNow;
            await _messageService.AddMessageAsync(message);
            // Notify all connected clients about the new message
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message.SenderId, message.Content);

            return CreatedAtAction(nameof(GetMessageById), new { userId = message.RecipientId }, message);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessageById(string id)
        {
            var message = await _messageService.GetMessageByIdAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }
    }
}
