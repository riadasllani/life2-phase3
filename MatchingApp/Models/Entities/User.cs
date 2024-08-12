using CsvHelper.Configuration.Attributes;

namespace MatchingApp.Models.Entities
{
    public class User
    {
        // YOUR CODE HERE
        // User should have the parameters as in the csv file
        // Id,Gender,Age,Credits,Active
        [Index(0)]
        public int UserId { get; set; }
        [Index(1)]
        public string Gender {  get; set; } //TODO: Later change it to enum
        [Index(2)]
        public int Age {  get; set; }
        [Index(3)]
        public long Credits {  get; set; }
        [Index(4)]
        public bool Active {  get; set; }
    }
}
