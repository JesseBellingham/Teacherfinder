namespace Teacherfinder.DataLayer.Repositories
{
    using Entities;
    using Interfaces.Repositories;
    using System;
    using System.Linq;

    public class PersonRepository : IPersonRepository
    {
        private readonly TeacherfinderDataContext _dataContext;

        public PersonRepository(TeacherfinderDataContext dataContext)
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

        public Person GetPersonByIdentity(string appUserId)
        {
            return _dataContext.Persons.FirstOrDefault(p => p.ApplicationUserId == appUserId);
        }

        public void UpdatePerson(Person person)
        {
            var personToUpdate = _dataContext.Persons.FirstOrDefault(p => p.ApplicationUserId == person.ApplicationUserId);
            personToUpdate.CurrentLocation = person.CurrentLocation;
            _dataContext.SaveChanges();
        }
    }
}