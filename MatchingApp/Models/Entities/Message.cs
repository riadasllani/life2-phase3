﻿namespace MatchingApp.Models.Entities
{
    public class Message
    {
        // Message should have sender, reciever, content, date ...
        
        public int Id { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
        public User Sender { get; set; }
        public User Receiver { get; set; }
    }
}
