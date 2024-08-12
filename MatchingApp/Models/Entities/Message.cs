using System.ComponentModel.DataAnnotations.Schema;

namespace MatchingApp.Models.Entities
{
    public class Message
    {
        // YOUR CODE HERE
        // Message should have sender, reciever, content, date ...

        public int Id { get; set; }

        //[ForeignKey("SenderId")]
        //public User Sender { get; set; }
        //public int SenderId { get; set; }
        //[ForeignKey("ReceiverId")]
        //public User Receiver { get; set; }
        //public int ReciverId { get; set; }

        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
