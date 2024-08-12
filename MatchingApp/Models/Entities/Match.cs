namespace MatchingApp.Models.Entities
{
    public class Match
    {
        // YOUR CODE HERE
        // in this table you should save the user who did the like and the user who was liked
        // as well as some flag that indicates if this was mutual and the date ...

        public string MatchId { get; set; }
        public User Id { get; set; }
        public string UserId { get; set; }
        public DateTime DateCreated { get; set; }
    }

}
