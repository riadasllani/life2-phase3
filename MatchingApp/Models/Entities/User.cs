namespace MatchingApp.Models.Entities
{
    public class User
    {
        // YOUR CODE HERE
        // User should have the parameters as in the csv file
        public string Id { get; set; } = Guid.NewGuid().ToString(); // left on purpose as string
        public string Gender { get; set; }
        public int Age { get; set; }
        public int Credits { get; set; }
        public bool IsActive { get; set; } // in case of not parsing or they get empty strings


        public ICollection<Match> UsersLiked { get; set; }
        public ICollection<Match> UsersWhoLiked { get; set; }

        public ICollection<Message> RecievedMessages { get; set; }
        public ICollection<Message> SentMessages { get; set; }

        // ka ni pik pytje te age, credits, isactive in case the values can not be parsed from string to theit tupes


    }
}
