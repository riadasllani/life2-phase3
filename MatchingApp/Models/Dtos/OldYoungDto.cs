using MatchingApp.Models.Entities;

namespace MatchingApp.Models.Dtos
{
    public class OldYoungDto
    {
        public User OldestUser { get; set; }
        public User YoungestUser { get; set; }
    }
}
