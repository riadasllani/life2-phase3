namespace MatchingApp.Models.Entities
{
    public class Message
    {
        public string Id { get; set; }
        public string SenderId { get; set; }
        public string RecieverId { get; set; }
        public User UserId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
