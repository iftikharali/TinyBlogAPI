using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TinyBlog.Extensions;
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
        IUserService userService;
        IAuthenticationService _authService;
        public UsersController(IUserService userService,IAuthenticationService authService)
        {
            this.userService = userService;
            this._authService = authService;
        }
        // GET: api/User
        [Route("~/api/v1/users")]
        [HttpGet]
        //[EnableQuery()]
        public async Task<IEnumerable<User>> GetAsync()
        {
            return await userService.GetUsers();
        }

        // GET: api/User/5
        [AllowAnonymous]
        [HttpGet("user/{id}")]
        public async Task<User> Get(uint id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string UserKey = identity.Claims.ToList()?.FirstOrDefault()?.Value;
            if(Convert.ToInt32(UserKey) == id)
            {
                //logged in user
                return await userService.GetLoggedInUser(id).ConfigureAwait(false);
            }
            else
            {
                //other user
                return await userService.GetUser(id).ConfigureAwait(false);
            }
            
        }

        // POST: api/User
        [AllowAnonymous]
        [Route("user")]
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                userService.CreateUser(new ApplicationContext(this.GetIdentityKey()), user);
                return CreatedAtAction(nameof(Get), new { UserKey = user.UserKey }, user);
            }
            
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT: api/User/5
        [HttpPut("user/{id}")]
        public void Put(uint id, [FromBody] string name)
        {
            userService.UpdateUserName(name);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("user/{id}")]
        public void Delete(uint id)
        {
            userService.DeleteUser(id);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _authService.Authenticate(request.Email, request.Password);
            if(user == null)
            {
                return BadRequest(new { message = "email or password is incorrect" });
            }
            return Ok(user);
        }
    }
}
