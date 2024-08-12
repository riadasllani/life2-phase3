using MatchingApp.Models.Enums;

namespace MatchingApp.Models.Dtos
{
    public class GetUsersDto
    {
        public int Id { get; set; }

        public int Credits { get; set; }
        public string Gender { get; set; }

        public int? IsActive { get; set; }
        public int Age { get; set; }

    }
}
