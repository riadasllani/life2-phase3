namespace MatchingApp.Models.Entities
{
    public class Match
    {
        // YOUR CODE HERE
        // in this table you should save the user who did the like and the user who was liked
        // as well as some flag that indicates if this was mutual and the date ...
		public int userLikeingId { get; set; }
		public User userLikeing { get; set; }
		public int userLikedId { get; set; }
		public User userLiked { get; set;}
		public bool mutualLikeing { get; set; }
		public DateTime date = DateTime.Now;
    }

}
