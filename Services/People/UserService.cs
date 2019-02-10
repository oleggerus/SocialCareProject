using DataRepository.RepositoryPattern;
using System.Linq;
using DataRepository.Entities.People;

namespace Services.People
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IQueryable<User> GetAllUsers()
        {
            return _userRepository.TableNoTracking;
        }

    }
}
