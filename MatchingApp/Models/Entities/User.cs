using System.ComponentModel.DataAnnotations.Schema;

namespace MatchingApp.Models.Entities
{
    public class User
    {
        // YOUR CODE HERE
        // User should have the parameters as in the csv file

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int Credits { get; set; }
        public bool Active { get; set; }
    }
}
