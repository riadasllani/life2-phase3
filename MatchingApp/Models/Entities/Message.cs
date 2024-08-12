using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchingApp.Models.Entities
{
    public class Message
    {
        // YOUR CODE HERE
        // Message should have sender, reciever, content, date ...
        [Key]
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }

        [ForeignKey("SenderId")]
        public User Sender { get; set; }
        
        [ForeignKey("ReceiverId")]

        public User Reciever { get; set; }
        
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
