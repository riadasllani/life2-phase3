using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchingApp.Models.Entities
{
    public class Message
    {
        public string Id { get; set; }
        [ForeignKey("SenderId")]
        public string SenderId {  get; set; }
        [ForeignKey("RecieverId")]
        public string RecieverId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public User Sender { get; set; }
        public User Reciever { get; set; }
        // YOUR CODE HERE
        // Message should have sender, reciever, content, date ...
    }
}
