namespace Classroom.DataLayer.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Location
    {
        public int LocationId { get; set; }
        [Required]
        public string LocationCity { get; set; }
        [Required]
        public string LocationCountry { get; set; }
    }
}