namespace Teacherfinder.DataLayer.Repositories
{
    using System;
    using System.Linq;
    using Entities;
    using System.Linq.Expressions;
    using Interfaces.Repositories;

    public class StudentRepository : IStudentRepository
    {
        private readonly TeacherfinderDataContext _dataContext;

        public StudentRepository(TeacherfinderDataContext dataContext)
        {
            if (dataContext == null)
            {
                throw new ArgumentNullException("dataContext");
            }

            _dataContext = dataContext;
        }

        public IQueryable<Student> GetStudents(Expression<Func<Student, bool>> filter)
        {
            return _dataContext.Students.Where(filter);
        }

        public IQueryable<Student> GetStudents()
        {
            return _dataContext.Students;
        }

        public void CreateStudent(Student student)
        {
            _dataContext.Students.Add(student);
            _dataContext.SaveChanges();
        }
    }
}