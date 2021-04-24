using System;
using System.Collections.Generic;
using _1234.Models.Login;
using _1234.Models.Users;

namespace _1234.Models.Repository.UserRepository
{
    public interface IUserRepository
    {
        IEnumerable<User> Get();
        User Get(int? id);
        User Get(LoginModel loginModel);
    }
}
