namespace Teacherfinder.DataLayer.Interfaces.Services
{
    using Entities;
    using System.Collections.Generic;

    public interface IEnrolmentService
    {
        List<Enrolment> GetEnrolments();
        List<Enrolment> GetEnrolmentsOfStudent(int studentId);
        Student CreateEnrolment(int studentId, int classId);
        List<Enrolment> GetEnrolmentsOfLesson(int classId);
    }
}
