using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazeChat.Server.Data.Entities
{
    [Table("Message")]
    public class Message
    {
        [Key]
        public long Id { get; set; }

        public int SenderId { get; set; }

        public int ReceiverId { get; set; }

        [Required, MaxLength(500)]
        public string Content { get; set; }

        public DateTime SendOn { get; set; }

        public virtual User Sender { get; set; }

        public virtual User Receiver { get; set; }
    }
}
