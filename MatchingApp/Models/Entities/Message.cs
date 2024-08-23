namespace MatchingApp.Models.Entities
{
    public class Message
    {
        // YOUR CODE HERE
        // Message should have sender, reciever, content, date ...
        public string Id { get; set; }
        public long SenderId { get; set; }
        public User UserSent { get; set; }
        public long RecieverId { get; set; }
        public User UserRecieved { get; set; }
        public string Content { get; set;}
        public DateTime DateTime { get; set; }

    }
}
