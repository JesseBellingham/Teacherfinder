namespace Teacherfinder.DataLayer.Services
{
    using Entities;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces.Repositories;
    using System;
    using Models;
    using Interfaces.Services;

    public class StudentService : IStudentService
    {

        private readonly IPersonService _personService;
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository, IPersonService personService)
        {
            if (studentRepository == null)
            {
                throw new ArgumentNullException("studentRepository");
            }
            if (personService == null)
            {
                throw new ArgumentNullException("personService");
            }

            _studentRepository = studentRepository;
            _personService = personService;
        }

        public List<Student> GetStudents()
        {
            return _studentRepository.GetStudents().ToList();
        }

        public Student GetStudentById(int studentId)
        {
            return _studentRepository.GetStudents(student => student.StudentId == studentId).SingleOrDefault();
        }

        public List<Student> GetStudentsOfLesson(int classId)
        {
            return
                _studentRepository.GetStudents
                (
                    student =>
                        student.Enrolments.Any(enrolment => enrolment.LessonId == classId)
                ).ToList();
        }

        public List<Student> GetEnrollableStudents(List<Student>existingStudents, int classId)
        {
            var names = existingStudents.Select(es => es.Person.LastName);
            return
                _studentRepository.GetStudents
                (
                    student =>
                        // I find !Any easier to read in this context than All()
                        // I don't think there is any real difference in the IL produced
                        !student.Enrolments.Any(enrolment => enrolment.LessonId == classId) &&
                        !names.Any(name => string.Equals(name, student.Person.LastName))
                ).ToList();
        }

        public Student CreateStudent
        (
            ApplicationUser user,
            string firstName,
            string lastName
        )
        {
            var person = _personService.CreatePerson(user.Id, firstName, lastName);
            //var person = _personService.GetPerson(personId);
            var student = new Student
            {
                PersonId = person.PersonId,                
            };

            _studentRepository.CreateStudent(student);
            return student;
        }
    }
}