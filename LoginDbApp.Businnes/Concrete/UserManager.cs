using LoginDbApp.Businnes.Abstract;
using LoginDbApp.DataAccess.Abstract;
using LoginDbApp.Entities;
using LoginDbApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoginDbApp.Businnes.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IEncryptOperation encryptOperation;

        public UserManager(
            IUserRepository userRepository,
            IEncryptOperation encryptOperation)
        {
            this.userRepository = userRepository;
            this.encryptOperation = encryptOperation;
        }

        public UserResult CreateUser(User user)
        {
            User FetchUser = userRepository.GetUserByEmail(user.Email);
            if (FetchUser != null)
            {

                return new UserResult { IsSuccess = false };
            }
            var encryptedPassword = encryptOperation.Encrypt(user.Password);
            user.Password = encryptedPassword;
            user.CreatedDate = DateTime.Now;
            userRepository.CreateUser(user);

            return new UserResult { IsSuccess = true, CreatedDate = DateTime.Now, IDUser = user.id };
        }




        public void DeleteUser(int id)
        {
            userRepository.DeleteUser(id);
        }

        public List<User> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            if(id>0)
                return userRepository.GetUserById(id);
            throw new Exception("ID can not be less than 0.");
        }

        public User UpdateUser(User user)
        {
            return userRepository.UpdateUser(user);
        }

        public User GetUserByEmail(string Email)
        {
            return userRepository.GetUserByEmail(Email);
        }

        public LoginResult LoginUser(Login login)
        {
            User FetchUser = userRepository.GetUserByEmail(login.Email);
            if (FetchUser != null)
            {
                var encryptedPassword = encryptOperation.Encrypt(login.Password);
                login.Password = encryptedPassword;
                login.LoginDate = DateTime.Now;
                if (encryptedPassword == FetchUser.Password)
                {
                    return new LoginResult { IsSuccess = true, LoginDate = DateTime.Now, Message = "Welcome" , IDUser = FetchUser.id};//okey
                }
                else
                {
                    return new LoginResult { IsSuccess = false, Message = "the Password is incorrect" };
                }
            }
                return new LoginResult { IsSuccess = false, Message = "the UserName is incorrect" };
        }

        public UserResult GetUserID(string email)
        {
            User user = userRepository.GetUserByEmail(email);
            return new UserResult { IsSuccess=true, IDUser= user.id, CreatedDate=DateTime.Now};
        }
    }
}
