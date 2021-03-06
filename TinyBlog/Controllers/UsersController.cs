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
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserRepository userRepository;
        IUserService _userService;
        public UsersController(IUserRepository userRepository,IUserService userService)
        {
            this.userRepository = userRepository;
            this._userService = userService;
        }
        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return userRepository.GetUsers();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            User user = new User();
            user.ID = 234234;
            user.Password = "asdf";
            user.Email = "asdomerkg";
            return user;
            //return userRepository.GetUser(id);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if(ModelState.IsValid)
            return CreatedAtAction(nameof(Get), new { id = user.ID }, user);
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string name)
        {
            userRepository.UpdateUserName(name);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            userRepository.DeleteUser(id);
        }
        [AllowAnonymous]
        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] User userParam)
        {
            var user = await _userService.Authenticate(userParam.Email, userParam.Password);
            if(user == null)
            {
                return BadRequest(new { message = "email or password is incorrect" });
            }
            return Ok(user);
        }
    }
}
