namespace Teacherfinder.DataLayer.Repositories
{
    using System;
    using System.Linq;
    using Entities;
    using System.Linq.Expressions;
    using Interfaces.Repositories;

    public class TeacherRepository : ITeacherRepository
    {
        private readonly TeacherfinderDataContext _dataContext;

        public TeacherRepository(TeacherfinderDataContext dataContext)
        {
            if (dataContext == null)
            {
                throw new ArgumentNullException("dataContext");
            }

            _dataContext = dataContext;
        }

        public IQueryable<Teacher> GetTeachers(Expression<Func<Teacher, bool>> filter)
        {
            return _dataContext.Teachers.Where(filter);
        }

        public Teacher GetTeacher(int personId)
        {
            return _dataContext.Teachers.FirstOrDefault(t => t.PersonId == personId);
        }

        public IQueryable<Teacher> GetTeachers()
        {
            return _dataContext.Teachers;
        }

        public void CreateTeacher(Teacher teacher)
        {
            _dataContext.Teachers.Add(teacher);
            _dataContext.SaveChanges();
        }
    }
}