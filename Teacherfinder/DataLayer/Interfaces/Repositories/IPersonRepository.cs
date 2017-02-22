using Teacherfinder.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teacherfinder.DataLayer.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        int CreatePerson(Person person);
        Person GetPerson(int personId);
        Person GetPersonByIdentity(string appUserId);
    }
}