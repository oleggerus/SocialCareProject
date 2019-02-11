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

        public User GetUserByEmail(string email)
        {
            return _userRepository.Table.SingleOrDefault(x => Equals(x.Email, email));
        }

        public string GetSaltByEmail(string email)
        {
            return _userRepository.Table.SingleOrDefault(x => Equals(x.Email, email))?.PasswordSalt;
        }
    }
}
