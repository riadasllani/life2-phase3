namespace MatchingApp.Models.Entities
{
    public class Message
    {
        // YOUR CODE HERE
        // Message should have sender, reciever, content, date ...
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
