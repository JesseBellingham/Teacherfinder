namespace Teacherfinder.DataLayer.Interfaces.Services
{
    using System.Collections.Generic;
    using Teacherfinder.DataLayer.Entities;
    using Teacherfinder.Models;
    public interface ITeacherService
    {
        List<Teacher> GetTeachers();
        Teacher GetTeacherById(int teacherId);
        //List<Teacher> GetStudentsOfLesson(int classId);
        //List<Teacher> GetEnrollableStudents(List<Teacher> existingStudents, int classId);
        Teacher CreateTeacher(ApplicationUser user, string teacherfirstName, string teacherlastName);
        bool PersonIsTeacher(int personId);
    }
}
