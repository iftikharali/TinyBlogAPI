﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;

namespace TinyBlog.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts(ApplicationContext context, int StartPage, int NumberOfPage, int NumberOfRecordPerPage);
        Task<IEnumerable<Post>> GetPosts(ApplicationContext context, int UserId, int StartPage, int NumberOfPage, int NumberOfRecordPerPage);
        Task<Post> GetPost(ApplicationContext context, int Id);
        bool UpdateTitle(ApplicationContext context, int Id, string Title);
        bool UpdateInformation(ApplicationContext context, int id, string PostContent);
        bool DeletePost(ApplicationContext context, int Id);
        Task<Post> CreatePost(ApplicationContext context, Post post);
        IEnumerable<Comment> getComments(ApplicationContext context, int postId);
        Comment getComment(ApplicationContext context, int commentId);
        Comment CreateComment(ApplicationContext context, string commentContent);
        Comment UpdateComment(ApplicationContext context, int Commentid, string commentContent);
        bool DeleteComment(ApplicationContext context, int Commentid);
    }
}
