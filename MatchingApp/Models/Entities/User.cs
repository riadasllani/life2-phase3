using MatchingApp.Models.Enums;

namespace MatchingApp.Models.Entities
{
    public class User
    {
        // YOUR CODE HERE
        // User should have the parameters as in the csv file
        public int Id { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public int Credits { get; set; }

        public int? IsActive { get; set; }
    }
}
