using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;
using TinyBlog.Repositories.Interfaces;
using TinyBlog.Services.Interfaces;

namespace TinyBlog.Services
{
    public class BlogService : IBlogService
    {
        private IBlogRepository blogRepository;
        public BlogService(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }
        private string MakeURLReadable(string url)
        {
            return url.Replace(" ", "-");
        }
        public async Task<Blog> CreateBlog(ApplicationContext context, Blog blog)
        {
            blog.BrowserTitle = blog.Title + " | TinyBlog | Where world comes to blog.";
            blog.BlogGuid = Guid.NewGuid();
            return await blogRepository.CreateBlog(context, blog);
        }

        public bool DeleteBlog(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Blog>> GetBlogs(ApplicationContext context, int StartPage, int NumberOfPage, int NumberOfRecordPerPage)
        {
            return await this.blogRepository.GetBlogs(context,StartPage, NumberOfPage, NumberOfRecordPerPage);
        }

        public async Task<IEnumerable<Blog>> GetBlogs(ApplicationContext context, int UserId, int StartPage, int NumberOfPage, int NumberOfRecordPerPage)
        {
            return await this.blogRepository.GetBlogs(context, UserId, StartPage, NumberOfPage, NumberOfRecordPerPage);
        }

        public async Task<Blog> GetBlog(ApplicationContext context, int Id)
        {
            return await this.blogRepository.GetBlog(context, Id);
        }

        public bool UpdateInformation(int Id, string BlogContent)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTitle(string Title)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Subscribe(ApplicationContext context, int blogKey)
        {
            return await this.blogRepository.Subscribe(context, blogKey);
        }

        public async Task<bool> Recommend(ApplicationContext context, int blogKey)
        {
            return await this.blogRepository.Recommend(context, blogKey);
        }
    }
}
