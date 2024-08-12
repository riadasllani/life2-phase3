namespace MatchingApp.Models.Entities
{
    public class Match
    {
        // YOUR CODE HERE
        // in this table you should save the user who did the like and the user who was liked
        // as well as some flag that indicates if this was mutual and the date ...
        public int Id { get; set; }
        public int? LikerId { get; set; }
        public User? Liker { get; set; }
        public int? LikedId { get; set; }
        public User? Liked { get; set; }
        public bool Mutual { get; set; } = false;
        public DateTime CreatedDate { get; set; }
    }

}
