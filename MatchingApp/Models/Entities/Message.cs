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

        [ForeignKey ("SenderId")]
        public int SenderId { get; set; }

        [ForeignKey ("ReciverId")]
        public int ReciverId { get; set; }

        public virtual User Sender { get; set; }
        public virtual User Reciver { get; set; }

        public string Content { get; set; }

        public DateTime DateTime { get; set; }

        
    }
}
