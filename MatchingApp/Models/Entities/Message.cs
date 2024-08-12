namespace MatchingApp.Models.Entities
{
    public class Message
    {
        // YOUR CODE HERE
        // Message should have sender, reciever, content, date ...
        public int SenderId { get; set; }
        public User Sender { get; set; }
        public int ReceiverId { get; set; }
        public User Receiver { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
