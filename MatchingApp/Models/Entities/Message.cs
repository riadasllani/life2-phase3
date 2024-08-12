namespace MatchingApp.Models.Entities
{
    public class Message
    {
        // YOUR CODE HERE
        // Message should have sender, reciever, content, date ...
		public int Id { get; set; }
		public string SenderId { get; set; }
		public User Sender { get; set; }
		public string content {get; set; }
		public DateTime date = DateTime.Now;
    }
}
