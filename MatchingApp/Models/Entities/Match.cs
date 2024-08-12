namespace MatchingApp.Models.Entities
{
    public class Match
    {
        public int Id { get; set; }
        public int FirstUserId { get; set; }
        public int SecondUserId { get; set; }
        public bool IsMutual { get; set; }
        public DateTime MatchDate { get; set; }
        public User FirstUser { get; set; }
        public User SecondUser { get; set; }
    }

}
