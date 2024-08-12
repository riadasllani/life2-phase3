using MatchingApp.Enums;

namespace MatchingApp.Models.Entities
{
    public class User
    {
         // User should have the parameters as in the csv file
         public string Id { get; set; }
         public Gender Gender { get; set; }
         public int Age { get; set; }
         public int Credits { get; set; }
         public bool Active { get; set; }
         public List<Match> Matches { get; set; }
         public List<Match> Matched { get; set; }
         public List<Message> SentMessages { get; set; }
         public List<Message> ReceivedMessages { get; set; }
    }
}
