using System.ComponentModel.DataAnnotations.Schema;

namespace MatchingApp.Models.Entities
{
    public class Match
    {
        // YOUR CODE HERE
        // in this table you should save the user who did the like and the user who was liked
        // as well as some flag that indicates if this was mutual and the date ...

        public int Id { get; set; }
        public User UserLike { get; set; }
        [ForeignKey("UserLikeId")]
        public long UserLikeId { get; set; }

        public User LikedUser { get; set; }
        [ForeignKey("LikedUserId")]
        public long LikedUserId { get; set; }
        public bool IsMutual { get; set; }
        public DateTime Date { get; set; }
    }

}
