using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TinyBlog.Models;
using TinyBlog.Repositories.Interfaces;

namespace TinyBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        IPostRepository postRepository;
        public PostsController(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }
        // GET: api/Posts
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return postRepository.GetPost(0, 1, 5);
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public Post Get(int id)
        {
            return postRepository.GetPost(id);
        }

        // POST: api/Posts
        [HttpPost]
        public void Post([FromBody] Post post)
        {
            postRepository.CreatePost(post);
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string content)
        {
            postRepository.UpdateInformation(id, content);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return postRepository.DeletePost(id);
        }

        [HttpGet("{post_Id}/comments")]
        public IEnumerable<Comment> comments(int post_Id)
        {
            return postRepository.getComments(post_Id);
        }

        [HttpGet("{post_Id}/comment/{comment_id}")]
        public Comment comments(int post_Id, int comment_id)
        {
            return postRepository.getComment(post_Id, comment_id);
        }
        [HttpPost("{post_Id}/comment")]
        public Comment Create(int post_Id, [FromBody] string commentContent)
        {
            return postRepository.CreateComment(commentContent);
        }

        [HttpPut("{post_Id}/comment/{id}")]
        public Comment Update(int post_Id,int id, [FromBody] string commentContent)
        {
            return postRepository.UpdateComment(id, commentContent);
        }
        [HttpDelete("{post_Id}/comment/{id}")]
        public bool Delete(int post_Id,int id)
        {
            return postRepository.DeleteComment(id);
           
        }
    }
}
