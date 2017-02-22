namespace Teacherfinder.DataLayer.Interfaces.Repositories
{
    using Entities;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface ILessonRepository
    {
        IQueryable<Lesson> GetLessons(Expression<Func<Lesson, bool>> filter);
        IQueryable<Lesson> GetLessons();
        int CreateLesson(Lesson newLesson);
        void UpdateLesson(Lesson existingLesson);
    }
}
