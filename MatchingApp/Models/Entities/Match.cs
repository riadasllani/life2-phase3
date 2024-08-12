using System.ComponentModel.DataAnnotations;

namespace MatchingApp.Models.Entities
{
    public class Match
    {
        // YOUR CODE HERE
        // in this table you should save the user who did the like and the user who was liked
        // as well as some flag that indicates if this was mutual and the date ...
        [Key]
        public int Id { get; set; }
        public int FirstUserId { get; set; }
        public int SecondUserId { get; set; }
        public bool IsMutual { get; set; }
        public DateTime MatchDate { get; set; }
    }

}
