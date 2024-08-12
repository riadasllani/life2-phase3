namespace MatchingApp.Models.Entities
{
    public class Match
    {
        public string Id { get; set; }
        public string UserLiked { get; set; }
        public string UserWasLiked { get; set; }
        public User UserId { get; set; }
        public bool WasLikeMutual { get; set; }
        public DateTime Date { get; set; }

    }

}

// YOUR CODE HERE
// in this table you should save the user who did the like and the user who was liked
// as well as some flag that indicates if this was mutual and the date ...
