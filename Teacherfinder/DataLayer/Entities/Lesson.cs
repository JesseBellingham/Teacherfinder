namespace Teacherfinder.DataLayer.Entities
{
    using System.Collections.Generic;

    public class Lesson
    {
        public int LessonId { get; set; }
        //[Required]
        //public string LessonName { get; set; }
        public Location Location { get; set; }
        public Teacher Teacher { get; set; }
        public LessonType LessonType { get; set; }

        public virtual ICollection<Enrolment> Enrolments { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}