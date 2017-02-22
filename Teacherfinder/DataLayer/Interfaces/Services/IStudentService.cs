namespace Teacherfinder.DataLayer.Interfaces.Services
{
    using Entities;
    using Models;
    using System.Collections.Generic;

    public interface IStudentService
    {
        List<Student> GetStudents();
        Student GetStudentById(int studentId);
        List<Student> GetStudentsOfLesson(int classId);
        List<Student> GetEnrollableStudents(List<Student> existingStudents, int classId);
        Student CreateStudent(ApplicationUser user, string studentfirstName, string studentlastName);
    }
}
