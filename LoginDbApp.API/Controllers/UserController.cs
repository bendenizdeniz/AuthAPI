using LoginDbApp.Businnes.Abstract;
using LoginDbApp.Entities;
using LoginDbApp.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginDbApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        
        [HttpGet]
        public List<User> Get()
        {
            return userService.GetAllUsers();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public User GetUserByID(int id)
        {
            return userService.GetUserById(id);
        }

        [HttpGet("{id}")]
        [Route("[action]/{Email}")]
        public UserResult GetUserID(string Email)
        {
            var user = userService.GetUserByEmail(Email);
            if (user != null)
            {
                return new UserResult { IsSuccess= true, CreatedDate=DateTime.Now, IDUser = user.id };
            }
            return new UserResult { IsSuccess = false };
        }

        [HttpGet]
        [Route("[action]/{Email}")]
        public IActionResult GetUserByEmail(string Email)
        {
            var user = userService.GetUserByEmail(Email);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost("CreateUser")]
        public UserResult Post([FromBody] User user)
        {
            return userService.CreateUser(user);
        }

        [HttpPut]
        public User Put([FromBody] User user)
        {
            return userService.UpdateUser(user) ;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            userService.DeleteUser(id);
        }

        [HttpPost]
        [Route("[Action]")]
        public LoginResult LoginUser([FromBody] Login loginRequest)
        {
            return userService.LoginUser(loginRequest);
        }

    }
}
