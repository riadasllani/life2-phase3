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

        
        public string UserLikedId { get; set; }
        public User UserLike { get; set; }
        
        public string UserWhoLikedId { get; set; }
        public User UserWhoLiked { get; set; }

        public bool IsMatch { get; set; }
        public DateTime DateCreated { get; set; }

    }

}
