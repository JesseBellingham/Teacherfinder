namespace Classroom.DataLayer.Services
{
    using Classroom.DataLayer.Entities;
    using Interfaces.Repositories;
    using System;

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

        public Person CreatePerson
        (
            string firstName,
            string lastName,
            int? personAge = null
        )
        {
            var person = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                Age = personAge
            };

            _personRepository.CreatePerson(person);
            return person;
        }
        public Person GetPerson(int personId)
        {
            return _personRepository.GetPerson(personId);
        }
    }

}