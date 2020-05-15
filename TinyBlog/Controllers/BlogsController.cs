using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Route("api/v1/blog/")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        IBlogService blogService;
        private readonly Appsettings _appSettings;

        public BlogsController(IBlogService blogService, IOptions<Appsettings> option)
        {
            this.blogService = blogService;
            this._appSettings = option.Value;
        }
        // GET: api/Blogs
        [AllowAnonymous]
        [HttpGet]
        [Route("~/api/v1/blogs/")]
        public async Task<IEnumerable<Blog>> Get()
        {
            return await blogService.GetBlogs(new ApplicationContext(this.GetIdentityKey(),_appSettings.BaseUrl), 0, 1, 5);
        }

        // GET: api/Blogs/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<Blog> Get(int id)
        {
            return await blogService.GetBlog(new ApplicationContext(this.GetIdentityKey(),this._appSettings.BaseUrl), id);
        }

        // POST: api/Blogs
        [HttpPost,DisableRequestSizeLimit]
        public IActionResult Post([FromForm] Blog blog)
        {
            var tags=Request.Form.Where(x=>x.Key=="Tags").Select(x=>x.Value).FirstOrDefault();
            var tag = tags.FirstOrDefault();
            blog.Tags = tag.Split(",").Select(x => new Tag() { Title = x }).ToList();
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string UserKey = identity.Claims.ToList()?.FirstOrDefault()?.Value;
            if (Request.Form.Files.Count > 0)
            {
                var folderName = Path.Combine("Resources", "Users\\" + UserKey + "\\blog");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                string fileName = Utility.SaveProfile(Request.Form.Files[0], folderName);
                blog.MainContentImageUrl = Path.Combine(folderName, fileName);
            }
            else
            {
                blog.MainContentImageUrl = blog.MainContentImageUrl.Replace(_appSettings.BaseUrl, "");
            }
            blogService.CreateBlog(new ApplicationContext(this.GetIdentityKey()),blog);
            return CreatedAtAction(nameof(Get), new { BlogKey = blog.BlogKey }, blog);
        }

        // PUT: api/Blogs/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string blogContent)
        {
            blogService.UpdateInformation(id,blogContent);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            blogService.DeleteBlog(id);
        }
    }
}
