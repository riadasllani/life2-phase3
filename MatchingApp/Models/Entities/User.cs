namespace MatchingApp.Models.Entities
{
    public class User
    {
         // YOUR CODE HERE
         // User should have the parameters as in the csv file
		 public string Id { get; set; }
		 public string Gender { get; set; }
		 public byte Age { get; set; }
		 public double Credits { get; set; }
		 public bool Active { get; set; }
    }
}
