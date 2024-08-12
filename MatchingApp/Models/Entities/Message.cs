using System.ComponentModel.DataAnnotations;

namespace MatchingApp.Models.Entities
{
    public class Message
    {
        // YOUR CODE HERE
        // Message should have sender, reciever, content, date ...

        [Key]
        public int Id { get; set; } 
        
        public string SenderId { get; set; }
        public User Sender { get; set; }


        public string recieverId { get; set; }
        public User Reciever { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        public string Content { get; set; }
    }
}
