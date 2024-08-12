namespace MatchingApp.Models.Entities
{
    public class Message
    {
        public int MessageId { get; set; }

        public String Sender { get; set; }

        public String Reciever { get; set; }

        public String Content { get; set; }

        public DateTime Date { get; set; }
    }
}
