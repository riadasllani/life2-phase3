using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace MatchingApp.Models.Entities
{
    public class Match
    {
        // in this table you should save the user who did the like and the user who was liked
        // as well as some flag that indicates if this was mutual and the date ...
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LikedUser { get; set; }
        public bool IsMutual { get; set; }
    }

}
