namespace MatchingApp.Models.Entities
{
    public class User
    {
        // YOUR CODE HERE
        // User should have the parameters as in the csv file
        public long Id { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public long Credits { get; set; }
        public int Active { get; set; }
    }
}
