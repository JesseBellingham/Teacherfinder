namespace Teacherfinder.DataLayer.Interfaces.Services
{
    using Entities;
    using Models.View;

    public interface IPersonService
    {
        Person CreatePerson(string appUserId, string firstName, string lastName, int? personAge = default(int?));
        Person GetPerson(int personId);
        Person GetPersonByIdentity(string appUserId);
        void UpdateLocation(string appUserId, PersonLocationModel model);
    }
}