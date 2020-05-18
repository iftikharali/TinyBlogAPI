using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using TinyBlog.Extensions;
using TinyBlog.Helper;
using TinyBlog.Models;
using TinyBlog.Repositories.Interfaces;
using TinyBlog.Services.Interfaces;

namespace TinyBlog.Controllers
{
    [Authorize]
    [Route("api/v1/post/")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        IPostService postService;
        private readonly Appsettings _appSettings;
        public PostsController(IPostService postService, IOptions<Appsettings> options)
        {
            this.postService = postService;
            this._appSettings = options.Value;
        }
        // GET: api/Posts
        [AllowAnonymous]
        [HttpGet]
        [Route("~/api/v1/posts")]
        public async Task<IEnumerable<Post>> Get()
        {
            return await postService.GetPosts(new ApplicationContext(this.GetIdentityKey(),_appSettings.BaseUrl), 0, 1, 5);
        }

        // GET: api/Posts/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<Post> Get(int id)
        {
            return await postService.GetPost(new ApplicationContext(this.GetIdentityKey(), _appSettings.BaseUrl), id);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("~/api/v1/postsbyuser/{UserKey}")]
        public async Task<IEnumerable<Post>> GetPostByUserAsync(int UserKey)
        {
            return await this.postService.GetPostsByUser(new ApplicationContext(this.GetIdentityKey(), _appSettings.BaseUrl), UserKey);
        }
        // POST: api/Posts
        [HttpPost,DisableRequestSizeLimit]
        public IActionResult Post([FromForm] Post post)
        {
            var tags = Request.Form.Where(x => x.Key == "Tags").Select(x => x.Value).FirstOrDefault();
            var tag = tags.FirstOrDefault();
            post.Tags = tag.Split(",").Select(x => new Tag() { Title = x }).ToList();
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string UserKey = identity.Claims.ToList()?.FirstOrDefault()?.Value;
            if (Request.Form.Files.Count > 0)
            {
                var folderName = Path.Combine("Resources", "Users\\" + UserKey + "\\blog");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                string fileName = Utility.SaveProfile(Request.Form.Files[0], folderName);
                post.MainContentImageUrl = Path.Combine(folderName, fileName);
            }
            else
            {
                post.MainContentImageUrl = post.MainContentImageUrl.Replace(_appSettings.BaseUrl, "");
            }
            postService.CreatePost(new ApplicationContext(this.GetIdentityKey()), post);
            return CreatedAtAction(nameof(Get), new { BlogKey = post.PostKey }, post);
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string content)
        {
            //postservice.UpdateInformation(id, content);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            //return postservice.DeletePost(id);
            return true;
        }

        [AllowAnonymous]
        [HttpGet("{post_Id}/comments")]
        public async Task<IEnumerable<Comment>> comments(int post_Id)
        {
            return await postService.GetComments(new ApplicationContext(this.GetIdentityKey(), _appSettings.BaseUrl), post_Id);
        }

        [AllowAnonymous]
        [HttpGet("{post_Id}/comment/{comment_id}")]
        public async Task<Comment> comments(int post_Id, int comment_id)
        {
            return await postService.GetComment(new ApplicationContext(this.GetIdentityKey(), _appSettings.BaseUrl), comment_id);
        }

        [HttpPost("{post_Id}/comment")]
        public async Task<Comment> Create(int post_Id, [FromBody] Comment comment)
        {
            comment.PostKey = post_Id;
            return await postService.CreateComment(new ApplicationContext(this.GetIdentityKey(), _appSettings.BaseUrl), comment);
        }

        [HttpPost("vote/{post_Id}")]
        public async Task<bool> Vote(int post_Id)
        {
            return await postService.Vote(new ApplicationContext(this.GetIdentityKey(), _appSettings.BaseUrl),post_Id);
        }
        [HttpPut("{post_Id}/comment/{id}")]
        public async Task<Comment> Update(int post_Id,int id, [FromBody] string commentContent)
        {
            return await postService.UpdateComment(new ApplicationContext(this.GetIdentityKey(), _appSettings.BaseUrl), id, commentContent);
        }
        [HttpDelete("{post_Id}/comment/{id}")]
        public bool Delete(int post_Id,int id)
        {
            return postService.DeleteComment(new ApplicationContext(this.GetIdentityKey(), _appSettings.BaseUrl), id);
           
        }
    }
}
