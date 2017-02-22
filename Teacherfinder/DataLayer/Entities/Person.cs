using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Teacherfinder.Models;

namespace Teacherfinder.DataLayer.Entities
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int? Age { get; set; }
        public int? HometownLocationId { get; set; }
        public int? CurrentLocationId { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("HometownLocationId")]
        public virtual Location HometownLocation { get; set; }
        [ForeignKey("CurrentLocationId")]
        public virtual Location CurrentLocation { get; set; }

    }
}