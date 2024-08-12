using System.ComponentModel.DataAnnotations.Schema;

namespace MatchingApp.Models.Entities
{
    public class Message
    {
        // YOUR CODE HERE
        // Message should have sender, reciever, content, date ...

        public int Id { get; set; }
        public User Sender { get; set; }
        public long SenderId { get; set; }
        public User Receiver { get; set; }
        public long RecevierId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
