using HairSalon.Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.ModelViews.Message
{
    public class MessageViewModel
    {
        public string Id { get; set; }            // Unique identifier for each message
        public string Content { get; set; }    // The text content of the message
        public DateTime Timestamp { get; set; } = DateTime.UtcNow; // Time the message was sent
        public string SenderId { get; set; }      
        public string RecipientId { get; set; }   // The user ID of the recipient
    }
}
