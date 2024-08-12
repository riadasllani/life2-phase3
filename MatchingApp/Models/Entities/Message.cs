namespace MatchingApp.Models.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        // Message should have sender, reciever, content, date ...
    }
}
