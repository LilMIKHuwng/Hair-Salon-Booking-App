using HairSalon.Core.Base;
using HairSalon.Core.Utils;
using HairSalon.Repositories.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Contract.Repositories.Entity
{
    public class Message: BaseEntity
    {
        public string Content { get; set; }    // The text content of the message
        public DateTime Timestamp { get; set; } // Time the message was sent

        // Relationships
        public Guid SenderId { get; set; }      // The user ID of the sender
        [ForeignKey("SenderId")]
        public virtual ApplicationUsers Sender { get; set; }       // Navigation property for the sender

        public Guid RecipientId { get; set; }   // The user ID of the recipient
        [ForeignKey(("RecipientId"))]
        public virtual ApplicationUsers Recipient { get; set; }

        public Message()
        {
            CreatedTime = CoreHelper.SystemTimeNow;
            LastUpdatedTime = CreatedTime;
        }
    }
}
