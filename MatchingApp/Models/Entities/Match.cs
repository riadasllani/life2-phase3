using System.ComponentModel.DataAnnotations.Schema;

namespace MatchingApp.Models.Entities
{
    public class Match
    {
        public int Id { get; set; }
        [ForeignKey("LikedByUserId")]
        public string LikedByUserId { get; set; }
        [ForeignKey("LikedUserId")]
        public string LikedUserId { get; set; }
        public bool Flag { get; set; } = false;
        public DateTime Date { get; set; }




        public User LikedBy { get; set; }
        public User LikedUser { get; set; }
        // YOUR CODE HERE
        // in this table you should save the user who did the like and the user who was liked
        // as well as some flag that indicates if this was mutual and the date ...
    }

}
