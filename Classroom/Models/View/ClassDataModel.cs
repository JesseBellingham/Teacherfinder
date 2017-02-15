namespace Classroom.Models.View
{
    using System.Collections.Generic;

    public class LessonDataModel
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public string TeacherName { get; set; }
        public string Location { get; set; }

        public List<EnrolmentModel> Enrolments { get; set; }
    }
}