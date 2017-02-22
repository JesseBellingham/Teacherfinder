namespace Teacherfinder.DataLayer.Services
{
    using Entities;
    using System.Collections.Generic;
    using Repositories;
    using System.Linq;
    using Interfaces;
    using Interfaces.Repositories;
    using System;
    using DomainModels;
    using Services;
    using Models;
    using Interfaces.Services;

    public class TeacherService : ITeacherService
    {

        private readonly IPersonService _personService;
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository, IPersonService personService)
        {
            if (teacherRepository == null)
            {
                throw new ArgumentNullException("teacherRepository");
            }
            if (personService == null)
            {
                throw new ArgumentNullException("personService");
            }

            _teacherRepository = teacherRepository;
            _personService = personService;
        }

        public List<Teacher> GetTeachers()
        {
            return _teacherRepository.GetTeachers().ToList();
        }

        public Teacher GetTeacherById(int teacherId)
        {
            return _teacherRepository.GetTeachers(teacher => teacher.TeacherId == teacherId).SingleOrDefault();
        }

        //public List<Teacher> GetTeacherOfLesson(int classId)
        //{
        //    return
        //        _teacherRepository.GetTeachers
        //        (
        //            teacher =>
        //                teacher.Enrolments.Any(enrolment => enrolment.LessonId == classId)
        //        ).ToList();
        //}

        //public List<Teacher> GetEnrollableTeachers(List<Teacher> existingTeachers, int classId)
        //{
        //    var names = existingTeachers.Select(es => es.Person.LastName);
        //    return
        //        _teacherRepository.GetTeachers
        //        (
        //            teacher =>
        //                // I find !Any easier to read in this context than All()
        //                // I don't think there is any real difference in the IL produced
        //                !teacher.Enrolments.Any(enrolment => enrolment.LessonId == classId) &&
        //                !names.Any(name => string.Equals(name, teacher.Person.LastName))
        //        ).ToList();
        //}

        public Teacher CreateTeacher
        (
            ApplicationUser user,
            string firstName,
            string lastName
        )
        {
            var person = _personService.CreatePerson(user.Id, firstName, lastName);
            var teacher = new Teacher
            {
                PersonId = person.PersonId,
            };

            _teacherRepository.CreateTeacher(teacher);
            return teacher;
        }

        public bool PersonIsTeacher(int personId)
        {
            //var person = _personService.GetPerson(personId);
            return _teacherRepository.GetTeacher(personId) != null;
        }
    }
}