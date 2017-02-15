namespace Classroom.DataLayer.Services
{
    using Entities;

    public interface IPersonService
    {
        Person CreatePerson(string firstName, string lastName, int? personAge = default(int?));
        Person GetPerson(int personId);
    }
}