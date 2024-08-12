namespace MatchingApp.Models.Entities
{
    public class Message
    {
        // YOUR CODE HERE
        // Message should have sender, reciever, content, date ...
        public int Id { get; set; } 
        public string Sender { get; set; }
        public User User1 { get; set; } 
        public string Receiver { get; set; }
        public User User2 { get; set; } 
        public string MessageContent { get; set; }  
        public DateTime DateCreated { get; set; }
    }
}
