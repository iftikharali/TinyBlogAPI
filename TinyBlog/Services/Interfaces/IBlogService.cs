using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;

namespace TinyBlog.Services.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<Blog>> GetBlogs(ApplicationContext context, int StartPage, int NumberOfPage, int NumberOfRecordPerPage);
        Task<IEnumerable<Blog>> GetBlogs(ApplicationContext context, int UserId, int StartPage, int NumberOfPage, int NumberOfRecordPerPage);

        Task<Blog> GetBlog(ApplicationContext context, int Id);
        bool UpdateTitle(string Title);
        bool UpdateInformation(int Id, string BlogContent);
        bool DeleteBlog(int Id);
        Task<Blog> CreateBlog(ApplicationContext context, Blog blog);
        Task<bool> Subscribe(ApplicationContext applicationContext, int blogKey);
        Task<bool> Recommend(ApplicationContext applicationContext, int blogKey);
    }
}
