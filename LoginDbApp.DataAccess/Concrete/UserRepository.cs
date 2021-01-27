using LoginDbApp.DataAccess.Abstract;
using LoginDbApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginDbApp.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        public User CreateUser(User user)
        {
            using (var userDbContext = new LoginAppDbContext())
            {
                userDbContext.Users.Add(user);
                userDbContext.SaveChanges();
                return user;
            }
        }

        public void DeleteUser(int id)
        {
            using (var userDbContext = new LoginAppDbContext())
            {
                var deletedUser = GetUserById(id);
                userDbContext.Remove(deletedUser);
                userDbContext.SaveChanges();
            }
        }

        public List<User> GetAllUsers()
        {
            using (var userDbContext = new LoginAppDbContext())
            {
                return userDbContext.Users.ToList();
            }
        }

        public User GetUserById(int id)
        {
            using (var userDbContext = new LoginAppDbContext())
            {
                return userDbContext.Users.Find(id);
            }
        }

        public User UpdateUser(User user)
        {
            using (var userDbContext = new LoginAppDbContext())
            {
                userDbContext.Users.Update(user);
                userDbContext.SaveChanges();
                return user;
            }
        }

        public User GetUserByEmail(string Email)
        {
            using (var userDbContext = new LoginAppDbContext())
            {
                return userDbContext.Users.FirstOrDefault(x => x.Email == Email);
            }
        }

        public UserResult GetUserID(string Email)
        {
            using (var userDbContext = new LoginAppDbContext())
            {
                User user = userDbContext.Users.FirstOrDefault(x => x.Email == Email);
                return new UserResult { IsSuccess = true, CreatedDate = DateTime.Now, IDUser = user.id };
            }
        }
    }
}
