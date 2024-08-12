namespace MatchingApp.Models.Entities
{
    public class Message
    {
        // YOUR CODE HERE
        // Message should have sender, reciever, content, date ...
        public User IdSender { get; set; }
        public User IdReciever { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
