namespace MatchingApp.Models.Entities
{
    public class Match
    {
        // YOUR CODE HERE
        // in this table you should save the user who did the like and the user who was liked
        // as well as some flag that indicates if this was mutual and the date ...
        public int Id { get; set; }
        public long HasLike { get; set; }
        public User UserHasLiked { get; set; }
        public long GotLiked { get; set; }
        public User UserGotLiked { get; set; }
        public bool IsMutual { get; set; }
    }

}
