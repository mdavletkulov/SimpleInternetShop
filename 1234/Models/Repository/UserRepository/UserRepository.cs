using System;
using System.Collections.Generic;
using System.Linq;
using _1234.Models.Login;
using _1234.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace _1234.Models.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {

        ApplicationContext Context;

        public UserRepository(ApplicationContext context)
        {
            Context = context;
        }

        public IEnumerable<User> Get()
        {
            return Context.Users.Include(u => u.Role);
        }

        public User Get(int? id)
        {
            return Context.Users.Include(u => u.Role).FirstOrDefault(u => u.Id == id);
        }

        public User Get(LoginModel loginModel)
        {
            return Context.Users.Include(u => u.Role).FirstOrDefault
                (u => u.Email == loginModel.Email &&
            u.Password == loginModel.Password);
        }
    }
}
