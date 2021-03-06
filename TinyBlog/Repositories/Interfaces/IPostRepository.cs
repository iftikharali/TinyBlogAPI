﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;

namespace TinyBlog.Repositories.Interfaces
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetPost(int StartPage, int NumberOfPage, int NumberOfRecordPerPage);
        IEnumerable<Post> GetPost(int UserId, int StartPage, int NumberOfPage, int NumberOfRecordPerPage);
        Post GetPost(int Id);
        bool UpdateTitle(int Id, string Title);
        bool UpdateInformation(int id, string PostContent);
        bool DeletePost(int Id);
        bool CreatePost(Post post);
        IEnumerable<Comment> getComments(int post_Id);
        Comment getComment(int post_Id, int comment_id);
        Comment CreateComment(string commentContent);
        Comment UpdateComment(int id, string commentContent);
        bool DeleteComment(int id);
    }
}
