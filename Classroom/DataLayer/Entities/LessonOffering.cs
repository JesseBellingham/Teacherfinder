using Classroom.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Classroom.DataLayer.Entities
{
    public class LessonOffering
    {
        public int LessonOfferingId { get; set; }
        [Required]
        public int MaxEnrolments { get; set; }
        public Lesson Lesson { get; set; }
        public Location Location { get; set; }
    }
}