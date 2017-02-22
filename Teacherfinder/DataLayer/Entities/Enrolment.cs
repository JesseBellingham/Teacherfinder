namespace Teacherfinder.DataLayer.Entities
{
    public class Enrolment
    {
        public int EnrolmentId { get; set; }
        public int LessonId { get; set; }
        public int StudentId { get; set; }

        public virtual Lesson Lesson { get; set; }
        public virtual Student Student { get; set; }
    }
}