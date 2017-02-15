namespace Classroom.DataLayer.Interfaces
{
    using DomainModels;
    using Entities;
    using System.Collections.Generic;

    public interface ILessonService
    {
        List<Lesson> GetLessons();
        Lesson GetLessonByName(string className);
        Lesson GetLessonById(int id);
        int CreateNewLesson(LessonModel model);
        bool UpdateLesson(LessonModel model);
    }
}
