using System.ComponentModel.DataAnnotations;

namespace MatchingApp.Models.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public int SenderId { get; set; }
        public User sender { get; set; }

        public int RecieverId { get; set; }
        public User reciever { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; } = DateTime.UtcNow;


        // YOUR CODE HERE
        // Message should have sender, reciever, content, date ...
    }
}
