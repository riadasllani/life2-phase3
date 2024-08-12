namespace MatchingApp.Models.Entities
{
    public class Message
    {
        // YOUR CODE HERE
        // Message should have sender, reciever, content, date ...
        public int Id { get; private set; }
        public int SenderId {  get; set; }
        public int ReceiverId { get; set; }
        public string MessageContent { get; set; } = null!;
        public DateTime MessageDate { get; private set; } = DateTime.UtcNow;

        public User Sender { get; set; } = null!;
        public User Receiver { get; set; } = null!; 
    }
}