using LoginDbApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoginDbApp.DataAccess.Abstract
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();

        User GetUserById(int id);

        User CreateUser(User user);

        User UpdateUser(User user);

        void DeleteUser(int id);

        public User GetUserByEmail (string Email);

        UserResult GetUserID(string Email);
    }
}
