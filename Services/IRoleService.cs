using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Entities;

namespace Services
{
    public interface IRoleService
    {
        Role GetRoleByAreaId(int id);
        List<int> GeAllowedAreasByUserId(int id);
    }
}
