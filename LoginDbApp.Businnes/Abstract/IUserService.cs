using LoginDbApp.Entities;
using LoginDbApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoginDbApp.Businnes.Abstract
{
    public interface IUserService
    {
        List<User> GetAllUsers();

        User GetUserById(int id);

        UserResult CreateUser(User user);

        User UpdateUser(User user);

        void DeleteUser(int id);

        LoginResult LoginUser(Login login);

        User GetUserByEmail(string email);

        UserResult GetUserID(string email);
    }
}
