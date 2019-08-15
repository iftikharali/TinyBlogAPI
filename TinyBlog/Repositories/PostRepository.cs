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

        public bool DeleteComment(int id)
        {
            return true;
        }

        public bool DeletePost(int Id)
        {
            return true;
        }

        public Comment getComment(int post_Id, int comment_id)
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
            List<Post> posts = new List<Post>()
            {
                new Post()
            };
            return posts;
        }

        public IEnumerable<Post> GetPost(int UserId, int StartPage, int NumberOfPage, int NumberOfRecordPerPage)
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
            };
            return posts;
        }

        public Post GetPost(int Id)
        {
            return new Post();
        }

        public Comment UpdateComment(int id, string commentContent)
        {
            Comment comment = new Comment();
            comment.ID = id;
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
