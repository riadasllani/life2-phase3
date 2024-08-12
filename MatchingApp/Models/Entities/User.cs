namespace MatchingApp.Models.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int Credits { get; set; }
        public bool Active { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Match> Matches { get; set; }
         // YOUR CODE HERE
         // User should have the parameters as in the csv file
    }
}
