namespace Teacherfinder.API
{
    using Models.View;
    using System;
    using System.Net.Http;
    using System.Web.Http;
    using System.Net;
    using DataLayer.Interfaces.Services;

    public class EnrolmentController : ApiController
    {        
        private readonly ILessonService _classService;
        private readonly IEnrolmentService _enrolmentService;
        private readonly IStudentService _studentService;

        public EnrolmentController
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

        [HttpPost]
        public HttpResponseMessage Create(EnrolmentModel model)
        {
            var student = _enrolmentService.CreateEnrolment(model.StudentId, model.LessonId);
            var resultModel = new EnrolmentModel
            {
                LessonId = model.LessonId,
                StudentId = student.StudentId,
                StudentFirstName = student.Person.FirstName,
                StudentLastName = student.Person.LastName
            };

            return Request.CreateResponse(HttpStatusCode.OK, resultModel);
        }
    }
}