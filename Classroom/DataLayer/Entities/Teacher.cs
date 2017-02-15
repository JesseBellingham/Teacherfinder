namespace Classroom.DataLayer.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Teacher
    {
        public int TeacherId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Location Hometown { get; set; }
        public virtual Location CurrentLocation { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}