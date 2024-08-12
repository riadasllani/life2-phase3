namespace MatchingApp.Models.Entities
{
    public class Message
    {
        // YOUR CODE HERE
        // Message should have sender, reciever, content, date ...

        public User sender { get; set; }
        public User reciever { get; set; }
        public String content { get; set; }
        public DateTime date { get; set; }
    }
}
