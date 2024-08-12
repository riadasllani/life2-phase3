namespace MatchingApp.Models.Entities
{
    public class Match
    {
        // YOUR CODE HERE
        // in this table you should save the user who did the like and the user who was liked
        // as well as some flag that indicates if this was mutual and the date ...
        public int FirstUserId { get; set; }
        public User UserWhoLiked { get; set; }
        public int SecondUserId { get; set; }
        public User UserWhoWasLiked { get; set; }

        public bool IsMutual { get; set; }



    }

}
