﻿using System.Linq;
using DataRepository.Entities.People;

namespace Services.People
{
    public interface IUserService
    {
        IQueryable<User> GetAllUsers();

        User GetUserByEmail(string email);

        string GetSaltByEmail(string email);

        int GetAdministrationIdByUserId(int userId);
        User UpdateUser(User user);
        User GetUserById(int id);

    }
}
