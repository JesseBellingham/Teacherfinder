namespace Teacherfinder.API
{
    using Models.View;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using DataLayer.Interfaces.Services;
    using Microsoft.AspNet.Identity;
    using DataLayer.Entities;

    public class PersonController : ApiController
    {
        private readonly IPersonService _personService;
        private readonly ITeacherService _teacherService;

        public PersonController
        (
            IPersonService personService,
            ITeacherService teacherService
            //IEnrolmentService enrolmentService,
            //IStudentService studentService
        )
        {
            if (personService == null)
            {
                throw new ArgumentNullException("personService");
            }
            if (teacherService == null)
            {
                throw new ArgumentNullException("teacherService");
            }
            _personService = personService;
            _teacherService = teacherService;
        }

        [HttpGet]
        public HttpResponseMessage Get()//int? personId)
        {
            //Person person;
            //if (personId == null || personId == 0)
            //{
                var person = _personService.GetPersonByIdentity(User.Identity.GetUserId());
            //}
            //else
            //{
            //    person = _personService.GetPerson(personId.Value);
            //}
            var model = new PersonModel
            {
                PersonId = person.PersonId,
                PersonFirstName = person.FirstName,
                PersonLastName = person.LastName,
                IsTeacher = _teacherService.PersonIsTeacher(person.PersonId)
            };

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        [HttpPost]
        public HttpResponseMessage UpdateLocation(PersonLocationModel model)//int? personId)
        {
            var appUserId = User.Identity.GetUserId();

            _personService.UpdateLocation(appUserId, model);

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        //public HttpResponseMessage Create(PersonModel model)
        //{
        //    var newPersonModel = new DataLayer.DomainModels.PersonModel
        //    {
        //        PersonName = model.PersonName,
        //        Location = model.Location,
        //        TeacherName = model.TeacherName
        //    };
        //    var classId = _classService.CreateNewPerson(newPersonModel);
        //    return Request.CreateResponse(HttpStatusCode.OK, classId);
        //}

        //public HttpResponseMessage Update(PersonModel model)
        //{
        //    var classModel = new DataLayer.DomainModels.PersonModel
        //    {
        //        PersonId = model.PersonId,
        //        PersonName = model.PersonName,
        //        TeacherName = model.TeacherName,
        //        Location = model.Location
        //    };
        //    var success = _classService.UpdatePerson(classModel);
        //    return Request.CreateResponse(HttpStatusCode.OK, success);
        //}
    }
}