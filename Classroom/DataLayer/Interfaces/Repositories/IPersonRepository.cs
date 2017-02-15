using Classroom.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Classroom.DataLayer.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        int CreatePerson(Person person);
        Person GetPerson(int personId);
    }
}