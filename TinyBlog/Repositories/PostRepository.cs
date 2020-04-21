using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;
using TinyBlog.Repositories.Interfaces;

namespace TinyBlog.Repositories
{
    public class PostRepository : IPostRepository
    {
        public Comment CreateComment(string commentContent)
        {
            Comment comment = new Comment();
            comment.Content = commentContent;
            return comment;
        }

        public bool CreatePost(Post post)
        {
            return true;
        }

        public bool DeleteComment(uint id)
        {
            return true;
        }

        public bool DeletePost(int Id)
        {
            return true;
        }

        public Comment getComment(uint comment_id)
        {
            return new Comment();
        }

        public IEnumerable<Comment> getComments(int post_Id)
        {
            List<Comment> comments = new List<Comment>()
            {
                new Comment()
            };
            return comments;
        }

        public IEnumerable<Post> GetPost(int StartPage, int NumberOfPage, int NumberOfRecordPerPage)
        {
            List<Post> posts = new List<Post>();
            //{
            //    new Post()
            //    {
            //        Title = "First",
            //        Url =  "http://localhost:4200/post/320/blog+title+new+url",
            //        MainContentImageUrl =  "http://localhost:4200/assets/images/blog.jpg",
            //        Excerpt = "First excerpt",
            //        Tags = new List<Tag>(){new Tag() },
            //        Category = new Category() { CategoryKey = 7, Name = "Digital Science" },
            //        Votes = 14

            //    }
            //};
            for (int i = 1; i <= 107; i++)
            {
                posts.Add(new Post()
                {
                    Title = "General Post " + i,
                    Url = "http://localhost:4200/post/320/blog+title+new+url",
                    MainContentImageUrl = "http://localhost:4200/assets/images/blog.jpg",
                    Excerpt = "Second excerpt " + i,
                    Tags = new List<Tag>() { new Tag() },
                    Category = new Category() { CategoryKey = (uint)(8+i), Name = "Artificial Intelligence" },
                    Votes = 149
                });
            }
            return posts;
        }

        public IEnumerable<Post> GetPost(int UserId, int StartPage, int NumberOfPage, int NumberOfRecordPerPage)
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
            };

            posts.Add(new Post());
            return posts;
        }

        public Post GetPost(int Id)
        {
            return new Post();
        }

        public Comment UpdateComment(uint id, string commentContent)
        {
            Comment comment = new Comment();
            comment.CommentKey = id;
            comment.Content = commentContent;
            return comment;
        }

        public bool UpdateInformation(int Id, string PostContent)
        {
            return true;
        }

        public bool UpdateTitle(int Id, string Title)
        {
            return true;
        }
    }
}
