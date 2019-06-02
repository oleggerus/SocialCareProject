using System;
using DataRepository.RepositoryPattern;
using System.Linq;
using System.Web.Mvc;
using DataRepository.Entities;
using DataRepository.Entities.People;
using DataRepository.Enums;

namespace Services.People
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        private readonly IWorkerService _workerService;

       public UserService(IRepository<User> userRepository,
            IWorkerService workerService)
        {
            _userRepository = userRepository;
            _workerService = workerService;
        }

        public IQueryable<User> GetAllUsers()
        {
            return _userRepository.TableNoTracking;
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.Table.SingleOrDefault(x => Equals(x.Email, email));
        }
        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _userRepository.Update(user);

            return user;
        }

        public string GetSaltByEmail(string email)
        {
            return _userRepository.Table.SingleOrDefault(x => Equals(x.Email, email))?.PasswordSalt;
        }


        public int GetAdministrationIdByUserId(int userId)
        {
            var userRoleArea = _userRepository.GetById(userId).Role.AreaId;
            switch (userRoleArea)
            {
                case (int)AreaTypes.Administration:
                return _workerService.GetWorkerByUserId(userId).Administration.Id;

                case (int)AreaTypes.Customer:
                    break;
            }

            return default(int);
        }
    }
}
