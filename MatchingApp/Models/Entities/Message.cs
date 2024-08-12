using System.ComponentModel.DataAnnotations;

namespace MatchingApp.Models.Entities
{
    public class Message
    {
        // YOUR CODE HERE
        // Message should have sender, reciever, content, date ...
        [Key]
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReciverId { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
