using System.ComponentModel.DataAnnotations;

namespace MatchingApp.Models.Entities
{
    public class User
    {

       
       public int Id { get; set; }
       public string Gender { get; set; }

        public int Age { get; set; }
        public int Credits { get; set; }
        public bool Active { get; set; } = false;
    }
}
//Id, Gender, Age, Credits, Active