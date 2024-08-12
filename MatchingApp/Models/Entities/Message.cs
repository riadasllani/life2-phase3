namespace MatchingApp.Models.Entities
{
    public class Message
    {
        // YOUR CODE HERE
        // Message should have sender, reciever, content, date ...
        public int Id { get; set; }
        public int? Sender { get; set; }
        public int? Receiver { get; set; }
        public string? Content { get; set; }
        public DateTime Date { get; set; }
    }
}
