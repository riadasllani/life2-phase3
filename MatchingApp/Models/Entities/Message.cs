using System.ComponentModel.DataAnnotations;

namespace MatchingApp.Models.Entities
{
    public class Message
    {
        // Message should have sender, reciever, content, date ...
        [Key]
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; } = DateTime.UtcNow;

    }
}
