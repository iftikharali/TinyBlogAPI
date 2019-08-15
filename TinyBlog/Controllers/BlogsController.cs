using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TinyBlog.Models;
using TinyBlog.Repositories;
using TinyBlog.Repositories.Interfaces;

namespace TinyBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        IBlogRepository blogRepository;

        public BlogsController(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }
        // GET: api/Blogs
        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            return blogRepository.GetBlog(0, 1, 5);
        }

        // GET: api/Blogs/5
        [HttpGet("{id}")]
        public Blog Get(int id)
        {
            return blogRepository.GetBlog(id);
        }

        // POST: api/Blogs
        [HttpPost]
        public IActionResult Post([FromBody] Blog blog)
        {
            blogRepository.CreateBlog(blog);
            return CreatedAtAction(nameof(Get), new { blog_Id = blog.ID }, blog);
        }

        // PUT: api/Blogs/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string blogContent)
        {
            blogRepository.UpdateInformation(id,blogContent);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            blogRepository.DeleteBlog(id);
        }
    }
}
