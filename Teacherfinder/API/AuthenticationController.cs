namespace Teacherfinder.API
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class AuthenticationController : ApiController
    {
        //[HttpGet]
        //public HttpResponseMessage Get(int? personId)
        //{
        //    Person person;
        //    if (personId == null)
        //    {
        //        person = _personService.GetPersonByIdentity(User.Identity.GetUserId());
        //    }
        //    else
        //    {
        //        person = _personService.GetPerson(personId.Value);
        //    }
        //    var model = new PersonModel
        //    {
        //        PersonId = person.PersonId,
        //        PersonFirstName = person.FirstName,
        //        PersonLastName = person.LastName,
        //        IsTeacher = _teacherService.PersonIsTeacher(person.PersonId)
        //    };

        //    return Request.CreateResponse(HttpStatusCode.OK, model);
        //}
    }
}
