using System.Linq;
using DataRepository.Entities.People;

namespace Services.People
{
    public interface IUserService
    {
        IQueryable<User> GetAllUsers();

        User GetUserByEmail(string email);

        string GetSaltByEmail(string email);

    }
}
