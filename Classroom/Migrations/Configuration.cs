namespace Classroom.Migrations
{
    using Classroom.DataLayer.Entities;
    using DataLayer.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataLayer.ClassroomDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Classroom.DataLayer.ClassroomDataContext context)
        {
            var persons = new List<Person>
            {
                new Person
                {
                    FirstName = "Carson",
                    LastName = "Alexander",
                    Age = 21
                },
                new Person
                {
                    FirstName = "Meredith",
                    LastName = "Alonso",
                    Age = 26
                },
                new Person
                {
                    FirstName = "Arthur",
                    LastName = "Johnson",
                    Age = 20
                },
                new Person
                {
                    FirstName = "Myrtle",
                    LastName = "Mooney",
                    Age = 38,
                    Location = new Location
                    {
                        LocationCity = "Auckland",
                        LocationCountry = "New Zealand"
                    },
                    //Instruments = new List<Instrument>
                    //{
                    //    new Instrument
                    //    {
                    //        InstrumentName = "Electric Guitar",
                    //        InstrumentType = new InstrumentType
                    //        {
                    //            InstrumentTypeDescription = "Strings"
                    //        }
                    //    }
                    //}
                }
            };
            persons.ForEach(s => context.Persons.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var lessons = new List<Lesson>
            {
                new Lesson
                {
                    //LessonName = "Chemistry",
                    //Location = "Building 7 Room 25",
                    //TeacherName = "Miss Jackson"
                },
                new Lesson
                {
                    //LessonName = "Biology",
                    //Location = "Building 13 Room 25",
                    //TeacherName = "Mr Mann"
                },
                new Lesson
                {
                    //LessonName = "Economics",
                    //Location = "Building 4 Room 13",
                    //TeacherName = "Mr Jeffreys"
                }
            };
            //classes.ForEach(c => context.Lessons.AddOrUpdate(p => p.LessonName, c));
            context.SaveChanges();

            //var enrolments = new List<Enrolment>
            //{
            //    new Enrolment
            //    {
            //        StudentId = persons.Single(s => s.LastName == "Alexander").StudentId,
            //        //LessonId = classes.Single(c => c.LessonName == "Chemistry" ).Id
            //    },
            //     new Enrolment
            //     {
            //        StudentId = persons.Single(s => s.LastName == "Johnson").StudentId,
            //        //LessonId = classes.Single(c => c.LessonName == "Biology" ).Id
            //     },
            //     new Enrolment
            //     {
            //        StudentId = persons.Single(s => s.LastName == "Mooney").StudentId,
            //        //LessonId = classes.Single(c => c.LessonName == "Economics" ).Id
            //     }
            //};

            //foreach (var enrolment in enrolments)
            //{
            //    var enrolmentExists =
            //        context.Enrolments.Any
            //        (
            //            e =>
            //                 e.Student.StudentId == enrolment.StudentId &&
            //                 e.Lesson.LessonId == e.LessonId
            //        );
            //    if (!enrolmentExists)
            //    {
            //        context.Enrolments.Add(enrolment);
            //    }
            //}
            context.SaveChanges();
        }
    }
}
