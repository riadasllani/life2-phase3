namespace MatchingApp.Models.Entities
{
    public class Match
    {
        // YOUR CODE HERE
        // in this table you should save the user who did the like and the user who was liked
        // as well as some flag that indicates if this was mutual and the date ...
        public int Id { get; set; } 
        public string UserWhoLiked { get; set; }
        public User User1 { get; set; }
        public string UserWhoWasLiked { get; set; }
        public User User2 { get; set; }
        public bool IsMutual { get; set;}
        public DateTime DateCreated { get; set; }  
    }

}
