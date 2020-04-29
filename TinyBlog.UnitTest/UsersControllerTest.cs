using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TinyBlog.Controllers;
using TinyBlog.Repositories.Interfaces;
using TinyBlog.Repositories;
using TinyBlog.Models;
using Microsoft.AspNetCore.Mvc;
using TinyBlog.Services;
using TinyBlog.Services.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Options;
using TinyBlog.Helper;

namespace TinyBlog.UnitTest
{
   
    public class UsersControllerTest
    {
        private IMapper mapper;
        private IOptions<Appsettings> options;
        public UsersControllerTest(IMapper mapper, IOptions<Appsettings> options)
        {
            this.mapper = mapper;
            this.options = options;
        }
        [Fact]
        public void GetUserTest()
        {

            IUserRepository userRepository = new UserRepository();
            IAuthenticationService userService = new AuthenticationService(this.mapper,this.options);
            UsersController usersController = new UsersController(userRepository,userService);
            List<User> users = usersController.Get().ToList();
            Assert.NotNull(users);
        }
        [Fact]
        public void GetUserByIDTest()
        {
            IUserRepository userRepository = new UserRepository();
            IAuthenticationService userService = new AuthenticationService(this.mapper, this.options);
            UsersController usersController = new UsersController(userRepository,userService);
            var users = usersController.Get(5);
            Assert.NotNull(users);
        }
        [Fact]
        public void CreateUserTest()
        {
            IUserRepository userRepository = new UserRepository();
            IAuthenticationService userService = new AuthenticationService(this.mapper, this.options);
            UsersController usersController = new UsersController(userRepository,userService);
            User user = new User();
            user.Name = "FirstUser";
            user.Email = "SomeEmail";
            var users = usersController.Post(user) as CreatedAtActionResult;
            var userValue = users.Value;
            Assert.IsType<User>(userValue);

        }
        [Fact]
        public void CreateUserWithInvalidDataTest()
        {
            IUserRepository userRepository = new UserRepository();
            IAuthenticationService userService = new AuthenticationService(this.mapper, this.options);
            UsersController usersController = new UsersController(userRepository,userService);
            User invalidUser = new User();
            invalidUser.Name = "FirstUser";
            usersController.ModelState.AddModelError("Email", "Email is mandatory");
            var users = usersController.Post(invalidUser);
            Assert.IsType<BadRequestObjectResult>(users);

        }
    }
}
