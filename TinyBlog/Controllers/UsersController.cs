﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TinyBlog.Models;
using TinyBlog.Repositories;
using TinyBlog.Repositories.Interfaces;
using TinyBlog.Services.Interfaces;

namespace TinyBlog.Controllers
{
    
    [Authorize]
    [Route("api/v1/")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserRepository userRepository;
        IAuthenticationService _userService;
        public UsersController(IUserRepository userRepository,IAuthenticationService userService)
        {
            this.userRepository = userRepository;
            this._userService = userService;
        }
        // GET: api/User
        [Route("~/api/v1/users")]
        [HttpGet]
        //[EnableQuery()]
        public IEnumerable<User> Get()
        {
            return userRepository.GetUsers();
        }

        // GET: api/User/5
        [HttpGet("user/{id}")]
        public User Get(int id)
        {
            User user = new User();
            user.UserKey = 234234;
            user.Password = "asdf";
            user.Email = "asdomerkg";
            return user;
            //return userRepository.GetUser(id);
        }

        // POST: api/User
        [AllowAnonymous]
        [Route("user")]
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if(ModelState.IsValid)
            return CreatedAtAction(nameof(Get), new { UserKey = user.UserKey }, user);
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT: api/User/5
        [HttpPut("user/{id}")]
        public void Put(uint id, [FromBody] string name)
        {
            userRepository.UpdateUserName(name);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("user/{id}")]
        public void Delete(uint id)
        {
            userRepository.DeleteUser(id);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userService.Authenticate(request.Email, request.Password);
            if(user == null)
            {
                return BadRequest(new { message = "email or password is incorrect" });
            }
            return Ok(user);
        }
    }
}
