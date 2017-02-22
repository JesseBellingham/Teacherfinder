namespace Teacherfinder.DataLayer.Services
{
    using Entities;
    using Interfaces.Repositories;
    using System;
    using Interfaces.Services;

    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            if (personRepository == null)
            {
                throw new ArgumentNullException("personRepository");
            }
            _personRepository = personRepository;
        }

        public Person CreatePerson(string appUserId, string firstName, string lastName, int? personAge = null)
        {
            var person = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                Age = personAge,
                ApplicationUserId = appUserId
            };

            _personRepository.CreatePerson(person);
            return person;
        }
        public Person GetPerson(int personId)
        {
            return _personRepository.GetPerson(personId);
        }

        public Person GetPersonByIdentity(string appUserId)
        {
            return _personRepository.GetPersonByIdentity(appUserId);
        }

        //public bool PersonIsTeacher(int personId)
        //{
        //    return _
        //}
    }
}