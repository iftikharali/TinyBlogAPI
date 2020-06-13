using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;

namespace TinyBlog.Services.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetPosts(ApplicationContext context, int StartPage, int NumberOfPage, int NumberOfRecordPerPage);
        Task<IEnumerable<Post>> GetPosts(ApplicationContext context, int UserId, int StartPage, int NumberOfPage, int NumberOfRecordPerPage);
        Task<Post> GetPost(ApplicationContext context, int Id);
        bool UpdateTitle(ApplicationContext context, int Id, string Title);
        bool UpdateInformation(ApplicationContext context, int id, string PostContent);
        bool DeletePost(ApplicationContext context, int Id);
        Task<Post> CreatePost(ApplicationContext context, Post post);
        Task<IEnumerable<Comment>> GetComments(ApplicationContext context, int postId);
        Task<Comment> GetComment(ApplicationContext context, int commentId);
        Task<Comment> CreateComment(ApplicationContext context, Comment comment);
        Task<Comment> UpdateComment(ApplicationContext context, int Commentid, string commentContent);
        bool DeleteComment(ApplicationContext context, int Commentid);
        Task<bool> Vote(ApplicationContext context, int postId);
        Task<IEnumerable<Post>> GetPostsByUser(ApplicationContext context, int UserKey);
        Task<IEnumerable<Post>> GetRecommendedPostAsync(ApplicationContext context, int postKey, int userKey);
    }
}
