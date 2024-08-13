namespace MatchingApp.Models.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public User Sender { get; set; }
        public User Reciever { get; set; }
    }
}
