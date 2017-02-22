namespace Teacherfinder.DataLayer.Interfaces.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Teacherfinder.DataLayer.Entities;

    public interface ITeacherRepository
    {
        IQueryable<Teacher> GetTeachers(Expression<Func<Teacher, bool>> filter);
        IQueryable<Teacher> GetTeachers();
        void CreateTeacher(Teacher teacher);
        Teacher GetTeacher(int personId);
    }
}
