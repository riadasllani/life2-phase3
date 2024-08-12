using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchingApp.Models.Entities
{
    public class Match
    {
        // YOUR CODE HERE
        // in this table you should save the user who did the like and the user who was liked
        // as well as some flag that indicates if this was mutual and the date ...

        [Key]
        public int Id { get; set; }

        [ForeignKey ("likedUser")]
        public int LikedUser { get; set; }

        [ForeignKey ("User1")]
        public int User1 { get; set; }
        public virtual User Liked { get; set; }
        public virtual User LikeGiver { get; set; }

        public bool IsMatch { get; set; } = false;

       
    }

}
