using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace MatchingApp.Models.Entities
{
    public class User
    {
        
        //Id,Gender,Age,Credits,Active
        //15624510,Male,19,19000,0
        
        
        public int Id { get; set; }
        public string? Gender { get; set; }
        public int? Age { get; set; }
        public string? Credits { get; set; }
        public bool? IsActive { get; set; } = true;

    }
}
