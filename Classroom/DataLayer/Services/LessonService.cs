namespace Classroom.DataLayer.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Entities;
    using Repositories;
    using Interfaces;
    using Interfaces.Repositories;
    using System;
    using DomainModels;

    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonService(ILessonRepository classRepository)
        {
            if (classRepository == null)
            {
                throw new ArgumentNullException("classRepository");
            }

            _lessonRepository = classRepository;
        }
        
        public List<Lesson> GetLessons()
        {
            return _lessonRepository.GetLessons().ToList();
        }

        public Lesson GetLessonByName(string className)
        {
            return new Lesson { }; //_classRepository.GetLessons(c => string.Equals(c.LessonName, className)).SingleOrDefault();
        }

        public Lesson GetLessonById(int id)
        {
            return _lessonRepository.GetLessons(c => c.LessonId == id).SingleOrDefault();
        }

        public int CreateNewLesson(LessonModel model)
        {
            var newLesson = new Lesson
            {
                //LessonName = model.LessonName,
                //Location = model.Location,
                //TeacherName = model.TeacherName
            };

            var classId = _lessonRepository.CreateLesson(newLesson);
            return classId;
        }

        public bool UpdateLesson(LessonModel model)
        {
            var success = false;
            var existingLesson = GetLessonById(model.LessonId);
            if (existingLesson != null)
            { 
                //existingLesson.LessonName = model.LessonName;
                //existingLesson.Location = model.Location;
                //existingLesson.TeacherName = model.TeacherName;

                _lessonRepository.UpdateLesson(existingLesson);
                success = true;
            }
            return success;
        }
    }
}