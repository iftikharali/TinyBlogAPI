using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;

namespace TinyBlog.Repositories.Interfaces
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetBlog(int StartPage, int NumberOfPage, int NumberOfRecordPerPage);
        IEnumerable<Blog> GetBlog(int UserId,int StartPage, int NumberOfPage, int NumberOfRecordPerPage);

        Blog GetBlog(int Id);
        bool UpdateTitle(string Title);
        bool UpdateInformation(int Id, string BlogContent);
        bool DeleteBlog(int Id);
        bool CreateBlog(Blog blog);
    }
}
