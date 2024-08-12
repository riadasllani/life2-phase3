namespace MatchingApp.Models.Entities
{
    public class Match
    {
        // in this table you should save the user who did the like and the user who was liked
        // as well as some flag that indicates if this was mutual and the date ...
        public string LikerId { get; set; }
        public string LikedId { get; set; }
        public bool IsMutual { get; set; }
        public DateTime LikedAt { get; set; }
        public User Liker { get; set; }
        public User Liked { get; set; }
    }

}
