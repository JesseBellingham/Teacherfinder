namespace Classroom.API
{
    using Models.View;
    using DataLayer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Web.Http;
    using System.Net;

    public class StudentEnrolmentController : ApiController
    {
        private readonly ILessonService _classService;
        private readonly IEnrolmentService _enrolmentService;
        private readonly IStudentService _studentService;

        public StudentEnrolmentController
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

        public HttpResponseMessage Get(int classId)
        {
            // This got messy fast
            // Implement an entity to viewmodel conversion class
            var enrolledStudents = _studentService.GetStudentsOfLesson(classId);
            var enrollableStudents = _studentService.GetEnrollableStudents(enrolledStudents, classId);
            var enrolledStudentModels = new List<EnrolmentModel>();
            var enrollableStudentModels = new List<EnrolmentModel>();

            foreach (var enrolledStudent in enrolledStudents)
            {
                enrolledStudentModels.Add
                (
                    new EnrolmentModel
                    {
                        StudentId = enrolledStudent.StudentId,
                        StudentFirstName = enrolledStudent.Person.FirstName,
                        StudentLastName = enrolledStudent.Person.LastName
                    }
                );
            }

            foreach (var enrollableStudent in enrollableStudents)
            {
                enrollableStudentModels.Add
                (
                    new EnrolmentModel
                    {
                        StudentId = enrollableStudent.StudentId,
                        StudentFirstName = enrollableStudent.Person.FirstName,
                        StudentLastName = enrollableStudent.Person.LastName
                    }
                );
            }

            var studentEnrolmentModel = new StudentEnrolmentModel
            {
                ExistingStudents = enrolledStudentModels,
                EnrollableStudents = enrollableStudentModels
            };

            return Request.CreateResponse(HttpStatusCode.OK, studentEnrolmentModel);
        }
    }
}