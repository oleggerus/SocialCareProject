using DataRepository.Entities;
using DataRepository.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using DataRepository.Entities.People;

namespace Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<User> _userRepository;

        public RoleService(IRepository<Role> roleRepository,
            IRepository<User> userRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }
        public Role GetRoleByAreaId(int id)
        {
            return _roleRepository.TableNoTracking.FirstOrDefault(x => x.AreaId == id);
        }

        public List<int> GeAllowedAreasByUserId(int id)
        {
            var role = _userRepository.TableNoTracking.FirstOrDefault(x => x.Id == id)?.Role.AreaId;
            return role != null ? new List<int> {role.Value} 
                                : new List<int> { 0 };
        }
    }
}
