using System.ComponentModel.DataAnnotations.Schema;

namespace MatchingApp.Models.Entities
{
    public class Match
    {
        // YOUR CODE HERE
        // in this table you should save the user who did the like and the user who was liked
        // as well as some flag that indicates if this was mutual and the date ...

        public int Id { get; set; }

        //public User SourceUser { get; set; }
        //[ForeignKey("SourceUserId")]
        //public int SourceUserId { get; set; }
       
        //public User TargetUser { get; set; }
      
        //[ForeignKey("TargetUserId")]
        //public int TargetUserId { get; set; }

        public  DateTime DateLiked { get; set; }
    }

}
