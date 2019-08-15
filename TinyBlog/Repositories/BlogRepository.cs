using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;
using TinyBlog.Repositories.Interfaces;

namespace TinyBlog.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        public bool CreateBlog(Blog blog)
        {
            return true;
        }

        public bool DeleteBlog(int Id)
        {
            return true;
        }

        public IEnumerable<Blog> GetBlog(int StartPage, int NumberOfPage, int NumberOfRecordPerPage)
        {
            List<Blog> blogs = new List<Blog>()
            {
                new Blog()
            };
            return blogs;
        }

        public IEnumerable<Blog> GetBlog(int UserId, int StartPage, int NumberOfPage, int NumberOfRecordPerPage)
        {
            List<Blog> blogs = new List<Blog>()
            {
                new Blog()
            };
            return blogs;
        }

        public Blog GetBlog(int Id)
        {
            return new Blog();
        }

        public bool UpdateInformation(int Id, string BlogContent)
        {
            return true;
        }

        public bool UpdateTitle(string Title)
        {
            return true;
        }
    }
}
