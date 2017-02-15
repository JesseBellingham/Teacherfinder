using System.ComponentModel.DataAnnotations;

namespace Classroom.DataLayer.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int? Age { get; set; }
        public Location Location { get; set; }
    }
}