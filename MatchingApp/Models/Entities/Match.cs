namespace MatchingApp.Models.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public string Liker { get; set; }
        public string Liked { get; set; }
        public User User { get; set; }
    }

}
