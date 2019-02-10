using System.Linq;
using DataRepository.Entities.People;

namespace Services.People
{
    public interface IUserService
    {
        IQueryable<User> GetAllUsers();
    }
}
