namespace Classroom.DataLayer.Services
{
    using System.Linq;
    using Entities;
    using Repositories;
    using System.Collections.Generic;
    using Interfaces;
    using Interfaces.Repositories;
    using System;

    public class EnrolmentService : IEnrolmentService
    {
        private readonly IEnrolmentRepository _enrolmentRepository;
        private readonly IStudentService _studentService;
        private readonly ILessonService _classService;

        public EnrolmentService
        (
            IEnrolmentRepository enrolmentRepository,
            IStudentService studentService,
            ILessonService classService
        )
        {
            if (enrolmentRepository == null)
            {
                throw new ArgumentNullException("enrolmentRepository");
            }
            if (studentService == null)
            {
                throw new ArgumentNullException("studentService");
            }
            if (classService == null)
            {
                throw new ArgumentNullException("classService");
            }

            _enrolmentRepository = enrolmentRepository;
            _studentService = studentService;
            _classService = classService;
        }

        public List<Enrolment> GetEnrolments()
        {
            return _enrolmentRepository.GetEnrolments().ToList();
        }

        public List<Enrolment> GetEnrolmentsOfStudent(int studentId)
        {
            return
                _enrolmentRepository.GetEnrolments(enrolment => enrolment.StudentId == studentId)
                .ToList();
        }

        public List<Enrolment> GetEnrolmentsOfLesson(int classId)
        {
            return
                _enrolmentRepository.GetEnrolments(enrolment => enrolment.LessonId == classId)
                .ToList();
        }

        public Student CreateEnrolment(int studentId, int classId)
        {
            var student = _studentService.GetStudentById(studentId);
            var classToEnrolInto = _classService.GetLessonById(classId);

            var enrolment = new Enrolment
            {
                Student = student,
                Lesson = classToEnrolInto
            };
            _enrolmentRepository.CreateEnrolment(enrolment);
            return student;
        }
    }
}