namespace MatchingApp.Models.Entities
{
    public class Match
    {

        public int Id { get; set; }  

        public int FirstUserId { get; set; }
        public User User1 { get; set; }

        public int SecondUserId { get; set; }
        public User User2 { get; set; }
        
        public bool IsMutual { get; set; }

        public DateTime MatchDate { get; set; }

        // YOUR CODE HERE
        // in this table you should save the user who did the like and the user who was liked
        // as well as some flag that indicates if this was mutual and the date ...
    }

}
