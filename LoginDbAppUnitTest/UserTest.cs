using LoginDbApp.Businnes.Abstract;
using LoginDbApp.Businnes.Concrete;
using LoginDbApp.DataAccess.Concrete;
using LoginDbApp.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LoginApplication.UnitTest
{
    public class UserTest
    {
        [Fact]

        public User GetUserById_Success()
        {
            UserRepository userRepository = new UserRepository();
            User user = userRepository.GetUserById(3);
            Assert.Equal(3, user.id);
            return user;
        }
    }
}
