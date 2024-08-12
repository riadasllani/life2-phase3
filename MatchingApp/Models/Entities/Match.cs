using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchingApp.Models.Entities
{
    public class Match
    {

        public int Id { get; set; }

        [ForeignKey("LikeUserId")]
        public int LikeUser { get; set; }

        [ForeignKey("LikedUserId")]
        public int LikedUser { get; set; }

        public bool Mutual { get; set; }

        public DateTime Date { get; set; }
        
    }

}
