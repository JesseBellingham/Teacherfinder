

namespace Classroom.DataLayer.Repositories
{
    using System;
    using System.Linq;
    using Entities;
    using System.Linq.Expressions;
    using Interfaces.Repositories;

    public class LessonRepository : ILessonRepository
    {
        private readonly ClassroomDataContext _dataContext;

        public LessonRepository(ClassroomDataContext dataContext)
        {
            if (dataContext == null)
            {
                throw new ArgumentNullException("dataContext");
            }

            _dataContext = dataContext;
        }

        public IQueryable<Lesson> GetLessons(Expression<Func<Lesson, bool>> filter)
        {            
            return _dataContext.Lessons.Where(filter);
        }

        public IQueryable<Lesson> GetLessons()
        {
            return _dataContext.Lessons;
        }

        public int CreateLesson(Lesson newLesson)
        {
            _dataContext.Lessons.Add(newLesson);
            _dataContext.SaveChanges();
            return newLesson.LessonId;
        }

        public void UpdateLesson(Lesson existingLesson)
        {
            var lessonToUpdate = _dataContext.Lessons.Where(c => c.LessonId == existingLesson.LessonId).Single();
            //classToUpdate.LessonName = existingLesson.LessonName;
            lessonToUpdate.Location = existingLesson.Location;
            //classToUpdate.TeacherName = existingLesson.TeacherName;

            _dataContext.SaveChanges();
        }
    }
}