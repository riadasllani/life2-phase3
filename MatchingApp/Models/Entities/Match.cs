using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.SignalR;

namespace MatchingApp.Models.Entities
{
    public class Match
    {
        // YOUR CODE HERE
        // in this table you should save the user who did the like and the user who was liked
        // as well as some flag that indicates if this was mutual and the date ...

        [Key]
        public int MatchId { get; set; }

        public int FirstUserId { get; set; }
        public int SecondUserId { get; set; }
        
        [ForeignKey("FirstUserId")]

        public User FirstUser { get; set; }
        
        [ForeignKey("SecondUserId")]

        public User SecondUser { get; set; }
        
        public bool IsMutual { get; set; }
        public DateTime MatchDate { get; set; }
    }

}
