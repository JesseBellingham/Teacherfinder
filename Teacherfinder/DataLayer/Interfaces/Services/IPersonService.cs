namespace Teacherfinder.DataLayer.Interfaces.Services
{
    using Entities;

    public interface IPersonService
    {
        Person CreatePerson(string appUserId, string firstName, string lastName, int? personAge = default(int?));
        Person GetPerson(int personId);
        Person GetPersonByIdentity(string appUserId);
    }
}