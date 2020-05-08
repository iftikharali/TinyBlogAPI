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
            List<Blog> blogs = new List<Blog>();
            for (int i = 1; i < 107; i++)
            {
                blogs.Add(new Blog()
                {
                    Url = "http://localhost:4200/blog/987979/the%2Bfirst%2Bpart%2Bis%2Bthe%2Basdf",
                    Title = "Blog Title "+i,
                    SubTitle = "Amazing blog and its content",
                    MainContentImageUrl = "http://localhost:4200/assets/images/coverimage.jpg",
                    Content = "This is an amazing blog and is very tremendous looking and was when created broke all the records and still it is continuing. When ever there is an event there will be an amaxing instances",
                    Owner = new User()
                    {
                        Name = "Awesome blogger user",
                        About = "Something amazing about this user"
                    },
                    Votes = 8987
                });
            }

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
            return new Blog()
            {
                Url = "http://localhost:4200/blog/987979/the%2Bfirst%2Bpart%2Bis%2Bthe%2Basdf",
                Title = "Awesome Blog Title",
                SubTitle = "Amazing blog and its content",
                MainContentImageUrl = "http://localhost:4200/assets/images/coverimage.jpg",
                MainContentImageSubtitle = "A camera that speaks all.",
                Content = @"<p>
                              Lorem ipsum dolor sit amet, consectetur adipiscing elit. In tempus sem augue, feugiat hendrerit lacus rutrum in. Vivamus faucibus ullamcorper nisi vitae auctor. Donec hendrerit accumsan lectus. Nulla gravida, orci in finibus elementum, felis est convallis neque, nec hendrerit urna odio ut nulla. Fusce augue nunc, ornare in risus at, porttitor molestie lectus. Aliquam a fermentum nulla. Sed molestie tristique leo eget lobortis. Pellentesque molestie pulvinar massa laoreet tristique. Cras convallis ac ante vitae lacinia. Nunc imperdiet elementum congue. In hac habitasse platea dictumst. Suspendisse iaculis bibendum dolor vitae blandit. Phasellus ac diam placerat, tempor mi ut, luctus dolor. Nulla facilisi.
                              </p>",
                Owner = new User()
                {
                    Name = "New Awesome user",
                    About = "Awesome user creates Awesome blogs",
                    ImageUrl = "http://localhost:4200/assets/images/user.jpg",
                    Categories = new List<Category>() { new Category() { Name = "Amazone Web Developer" } },
                    Vote = 243
                },
                Recommends = new List<Recommend>() { new Recommend()},
                Votes = 8987
            };
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
