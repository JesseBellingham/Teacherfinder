namespace Teacherfinder.API
{
    using Models.View;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using DataLayer.Interfaces.Services;

    public class LessonController : ApiController
    {
        private readonly ILessonService _classService;
        private readonly IEnrolmentService _enrolmentService;
        private readonly IStudentService _studentService;

        public LessonController
        (
            ILessonService classService,
            IEnrolmentService enrolmentService,
            IStudentService studentService
        )
        {
            if (classService == null)
            {
                throw new ArgumentNullException("classService");
            }
            if (enrolmentService == null)
            {
                throw new ArgumentNullException("enrolmentService");
            }
            if (studentService == null)
            {
                throw new ArgumentNullException("studentService");
            }

            _classService = classService;
            _enrolmentService = enrolmentService;
            _studentService = studentService;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            var lessons = _classService.GetLessons();
            var models = new List<LessonDataModel>();

            foreach (var lesson in lessons)
            {
                var enrolments = _enrolmentService.GetEnrolmentsOfLesson(lesson.LessonId);
                var enrolmentModels = new List<EnrolmentModel>();

                //foreach (var enrolment in enrolments)
                //{
                //    enrolmentModels.Add
                //    (
                //        new EnrolmentModel
                //        {
                //            StudentId = enrolment.StudentId,
                //            LessonId = enrolment.LessonId,
                //            StudentFirstName = enrolment.Student.Person.FirstName,
                //            StudentLastName = enrolment.Student.Person.LastName,
                //            StudentAge = enrolment.Student.Person.Age,
                //        }
                //    );
                //}
                //models.Add
                //(
                //    new LessonDataModel
                //    {
                //        LessonId = lesson.LessonId,
                //        //LessonName = Teacherfinder.LessonName,
                //        //TeacherName = Teacherfinder.TeacherName,
                //        //Location = Teacherfinder.Location,
                //        Enrolments = enrolmentModels
                //    }
                //);
            }
            return Request.CreateResponse(HttpStatusCode.OK, models);
        }

        public HttpResponseMessage Create(LessonModel model)
        {
            var newLessonModel = new DataLayer.DomainModels.LessonModel
            {
                LessonName = model.LessonName,
                Location = model.Location,
                TeacherName = model.TeacherName
            };
            var classId = _classService.CreateNewLesson(newLessonModel);
            return Request.CreateResponse(HttpStatusCode.OK, classId);
        }

        public HttpResponseMessage Update(LessonModel model)
        {
            var classModel = new DataLayer.DomainModels.LessonModel
            {
                LessonId = model.LessonId,
                LessonName = model.LessonName,
                TeacherName = model.TeacherName,
                Location = model.Location
            };
            var success = _classService.UpdateLesson(classModel);
            return Request.CreateResponse(HttpStatusCode.OK, success);
        }
    }
}