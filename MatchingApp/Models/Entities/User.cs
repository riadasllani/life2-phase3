using System.ComponentModel.DataAnnotations;

namespace MatchingApp.Models.Entities
{
    public class User
    {
         // YOUR CODE HERE
         // User should have the parameters as in the csv file
         public int Id { get; set; }
         [MaxLength(255)]
         public string Gender { get; set; }
         public int Age { get; set; }
         public int Credits { get; set; }
         public bool Active { get; set; }
    }
}
