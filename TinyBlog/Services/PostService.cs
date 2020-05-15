using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;
using TinyBlog.Repositories.Interfaces;
using TinyBlog.Services.Interfaces;

namespace TinyBlog.Services
{
    public class PostService : IPostService
    {
        private IPostRepository postRepository;
        public PostService(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }
        public Task<Comment> CreateComment(ApplicationContext context, string commentContent)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> CreatePost(ApplicationContext context, Post post)
        {
            post.PostGuid = Guid.NewGuid();
            post.BrowserTitle = post.Title + " | TinyBlog | Where world comes to blog.";

            return await postRepository.CreatePost(context, post);
        }

        public bool DeleteComment(ApplicationContext context, int Commentid)
        {
            throw new NotImplementedException();
        }

        public bool DeletePost(ApplicationContext context, int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> getComment(ApplicationContext context, int commentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comment>> getComments(ApplicationContext context, int postId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetPosts(ApplicationContext context, int StartPage, int NumberOfPage, int NumberOfRecordPerPage)
        {
            return await this.postRepository.GetPosts(context, StartPage, NumberOfPage, NumberOfRecordPerPage);
        }

        public async Task<IEnumerable<Post>> GetPosts(ApplicationContext context, int UserId, int StartPage, int NumberOfPage, int NumberOfRecordPerPage)
        {
            return await this.postRepository.GetPosts(context, StartPage, NumberOfPage, NumberOfRecordPerPage);
        }

        public async Task<Post> GetPost(ApplicationContext context, int Id)
        {
            return await this.postRepository.GetPost(context, Id);
        }

        public Task<Comment> UpdateComment(ApplicationContext context, int Commentid, string commentContent)
        {
            throw new NotImplementedException();
        }

        public bool UpdateInformation(ApplicationContext context, int id, string PostContent)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTitle(ApplicationContext context, int Id, string Title)
        {
            throw new NotImplementedException();
        }
    }
}
