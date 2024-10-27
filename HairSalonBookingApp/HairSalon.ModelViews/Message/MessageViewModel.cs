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
        public DateTime Timestamp { get; set; }  // Time the message was sent
        public Guid SenderId { get; set; }      
        public Guid RecipientId { get; set; }   // The user ID of the recipient
    }
}
