namespace Classroom.DataLayer.Repositories
{
    using Entities;
    using Interfaces.Repositories;
    using System;
    using System.Linq;

    public class PersonRepository : IPersonRepository
    {
        private readonly ClassroomDataContext _dataContext;

        public PersonRepository(ClassroomDataContext dataContext)
        {
            if (dataContext == null)
            {
                throw new ArgumentNullException("dataContext");
            }

            _dataContext = dataContext;
        }

        public int CreatePerson(Person person)
        {
            _dataContext.Persons.Add(person);
            _dataContext.SaveChanges();
            return person.PersonId;
        }

        public Person GetPerson(int personId)
        {
            return _dataContext.Persons.FirstOrDefault(p => p.PersonId == personId);
        }
    }
}