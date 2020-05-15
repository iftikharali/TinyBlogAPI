using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TinyBlog.Extensions;
using TinyBlog.Helper;
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
        private readonly Appsettings _appSettings;
        public UsersController(IUserService userService, IOptions<Appsettings> option, IAuthenticationService authService)
        {
            this.userService = userService;
            this._authService = authService;
            this._appSettings = option.Value;
        }
        // GET: api/User
        [Route("~/api/v1/users")]
        [HttpGet]
        //[EnableQuery()]
        public async Task<IEnumerable<User>> GetAsync()
        {
            return await userService.GetUsers(new ApplicationContext(this.GetIdentityKey(),_appSettings.BaseUrl));
        }

        // GET: api/User/5
        [AllowAnonymous]
        [HttpGet("user/{id}")]
        public async Task<User> Get(int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string UserKey = identity.Claims.ToList()?.FirstOrDefault()?.Value;
            if(Convert.ToInt32(UserKey) == id)
            {
                //logged in user
                return await userService.GetLoggedInUser(id, new ApplicationContext(this.GetIdentityKey(),_appSettings.BaseUrl)).ConfigureAwait(false);
            }
            else
            {
                //other user
                return await userService.GetUser(id,new ApplicationContext(this.GetIdentityKey(),_appSettings.BaseUrl)).ConfigureAwait(false);
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
        [HttpPut("user/{id}"),DisableRequestSizeLimit]
        public void Put(int id, [FromForm] User user)
        {
            user.About = user.About == "null" ? null : user.About;
            user.Phone = user.Phone == "null" ? null : user.Phone;
            user.Website = user.Website == "null" ? null : user.Website;
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string UserKey = identity.Claims.ToList()?.FirstOrDefault()?.Value;
            if (Request.Form.Files.Count > 0)
            {
                var folderName = Path.Combine("Resources", "Users\\" + UserKey + "\\profile");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                string fileName = Utility.SaveProfile(Request.Form.Files[0], folderName);
                user.ImageUrl = Path.Combine(folderName, fileName);
            }
            else
            {
                user.ImageUrl = user.ImageUrl.Replace(_appSettings.BaseUrl, "");
            }
            userService.UpdateUser(new ApplicationContext(this.GetIdentityKey()), user);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("user/{id}")]
        public void Delete(int id)
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
