namespace Teacherfinder.API
{
    using System;
    using System.Net.Http;
    using System.Web.Http;
    using Models.View;
    using System.Net;
    using DataLayer.Interfaces.Services;

    public class StudentController : ApiController
    {
        private readonly ILessonService _classService;
        private readonly IEnrolmentService _enrolmentService;
        private readonly IStudentService _studentService;
        private readonly IPersonService _personService;

        public StudentController
        (
            ILessonService classService,
            IEnrolmentService enrolmentService,
            IStudentService studentService,
            IPersonService personService
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
            if (personService == null)
            {
                throw new ArgumentNullException("personService");
            }

            _classService = classService;
            _enrolmentService = enrolmentService;
            _studentService = studentService;
            _personService = personService;
        }

        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Create(EnrolmentModel model)
        {
            //var person = _studentService
            //var student = _personService.GetPerson(model.)
            //    _studentService.CreateStudent
            //    (
            //        model.StudentFirstName,
            //        model.StudentLastName                    
            //    );

            //var response = student == null ?
            //    Request.CreateResponse(HttpStatusCode.BadRequest) :
            //    Request.CreateResponse(HttpStatusCode.OK, student);

            //return response;
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}