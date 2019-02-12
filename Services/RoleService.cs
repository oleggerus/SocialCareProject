using DataRepository.Entities;
using DataRepository.RepositoryPattern;
using System;
using System.Linq;

namespace Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _roleRepository;
        public RoleService(IRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public Role GetRoleByAreaId(int id)
        {
            return _roleRepository.TableNoTracking.FirstOrDefault(x => x.AreaId == id);
        }
    }
}
