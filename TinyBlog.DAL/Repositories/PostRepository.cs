using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.DAL.Helpers.Interfaces;
using TinyBlog.Models;
using TinyBlog.Repositories.Interfaces;

namespace TinyBlog.Repositories
{
    public class PostRepository : IPostRepository
    {
        private IDALHelper helper;
        public PostRepository(IDALHelper helper)
        {
            this.helper = helper;
        }
        public async Task<Comment> CreateComment(ApplicationContext context, Comment comment)
        {
            using (SqlCommand command = this.helper.GetCommand(@"Insert into [dbo].[Comment]
                                                    (CommentGuid, ParentCommentKey, Content, PostKey, CreatedBy,  UpdatedBy) 
                                                  values(@CommentGuid, @ParentCommentKey, @Content, @PostKey, @CreatedBy, @UpdatedBy)"))
            {

                command.Parameters.AddWithValue("@CommentGuid", (object)comment.CommentGuid ?? DBNull.Value);
                command.Parameters.AddWithValue("@ParentCommentKey", (object)comment.ParentCommentKey ?? DBNull.Value);
                command.Parameters.AddWithValue("@Content", (object)comment.Content ?? DBNull.Value);
                command.Parameters.AddWithValue("@PostKey", (object)comment.PostKey ?? DBNull.Value);
                command.Parameters.AddWithValue("@CreatedBy", context.UserKey);
                command.Parameters.AddWithValue("@UpdatedBy", context.UserKey);
                try
                {
                    int IsQuerySucess = await this.helper.ExecuteNonQueryAsync(command).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    string st = s;
                }
            }
            return comment;
        }

        public async Task<Post> CreatePost(ApplicationContext context, Post post)
        {
            using (SqlCommand command = this.helper.GetCommand(@"Insert into [dbo].[Post]
                                                    (BlogKey,PostGuid,Title,SubTitle,MainContentImageUrl,MainContentImageSubtitle,BrowserTitle,AuthorKey,Url,SortUrl,Content,CreatedBy,UpdatedBy) 
                                                  values(@BlogKey,@PostGuid,@Title,@SubTitle,@MainContentImageUrl,@MainContentImageSubtitle,@BrowserTitle,@AuthorKey,@Url,@SortUrl,@Content,@CreatedBy,@UpdatedBy)"))
            {

                command.Parameters.AddWithValue("@BlogKey", post.BlogKey);
                command.Parameters.AddWithValue("@PostGuid", (object)post.PostGuid ?? DBNull.Value);
                command.Parameters.AddWithValue("@Title", (object)post.Title ?? DBNull.Value);
                command.Parameters.AddWithValue("@SubTitle", (object)post.SubTitle ?? DBNull.Value);
                command.Parameters.AddWithValue("@MainContentImageUrl", (object)post.MainContentImageUrl ?? DBNull.Value);
                command.Parameters.AddWithValue("@MainContentImageSubtitle", (object)post.MainContentImageSubtitle ?? DBNull.Value);
                command.Parameters.AddWithValue("@BrowserTitle", (object)post.BrowserTitle ?? DBNull.Value);
                command.Parameters.AddWithValue("@AuthorKey", context.UserKey);
                command.Parameters.AddWithValue("@Url", (object)post.Url ?? DBNull.Value);
                command.Parameters.AddWithValue("@SortUrl", (object)post.SortUrl ?? DBNull.Value);
                command.Parameters.AddWithValue("@Content", (object)post.Content ?? DBNull.Value);
                command.Parameters.AddWithValue("@CreatedBy", context.UserKey);
                command.Parameters.AddWithValue("@UpdatedBy", context.UserKey);
                try
                {
                    int IsQuerySucess = await this.helper.ExecuteNonQueryAsync(command).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    string st = s;
                }
            }
            return post;
        }

        public bool DeleteComment(ApplicationContext context, int id)
        {
            return true;
        }

        public bool DeletePost(ApplicationContext context, int Id)
        {
            return true;
        }

        public async Task<Comment> GetComment(ApplicationContext context, int comment_id)
        {

            Comment comment = new Comment();
            using (SqlCommand command = this.helper.GetCommand("SELECT CommentKey, CommentGuid, ParentCommentKey, Content, PostKey, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy FROM [dbo].[Comment] WHERE CommentKey = @CommentKey"))
            {
                command.Parameters.AddWithValue("@CommentKey", comment_id);
                using (DbDataReader reader = await this.helper.ExecuteReaderAsync(command).ConfigureAwait(false))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            comment.CommentKey = reader.GetInt32("CommentKey");
                            comment.CommentGuid = reader.GetGuid("CommentGuid");
                            comment.ParentCommentKey = reader["ParentCommentKey"] == DBNull.Value ? null : (int?)reader["ParentCommentKey"];// "Blog Title " + i,
                            comment.Content = reader.GetString("Content");// "Amazing blog and its content",
                            comment.PostKey = reader["PostKey"] == DBNull.Value ? 0 : (int)reader["PostKey"];
                            comment.CreatedAt = reader.GetDateTime("CreatedAt");// "This is an amazing blog and is very tremendous looking and was when created broke all the records and still it is continuing. When ever there is an event there will be an amaxing instances",
                            //comment.CreatedBy = reader.GetInt32("CreatedBy");// "This is an amazing blog and is very tremendous looking and was when created broke all the records and still it is continuing. When ever there is an event there will be an amaxing instances",
                            comment.UpdatedAt = reader.GetDateTime("UpdatedAt");// "This is an amazing blog and is very tremendous looking and was when created broke all the records and still it is continuing. When ever there is an event there will be an amaxing instances",
                            comment.UpdatedBy = new User()
                            {
                                Name = "Awesome blogger user",
                                About = "Something amazing about this user"
                            };
                        }
                    }
                }
            }
            return comment;
        }

        public async Task<IEnumerable<Comment>> GetComments(ApplicationContext context, int post_Id)
        {
            List<Comment> comments = new List<Comment>();
            using (SqlCommand command = this.helper.GetCommand("SELECT CommentKey, CommentGuid, ParentCommentKey, Content, PostKey, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy FROM [dbo].[Comment] WHERE PostKey = @PostKey"))
            {

                command.Parameters.AddWithValue("@PostKey", post_Id);
                using (DbDataReader reader = await this.helper.ExecuteReaderAsync(command).ConfigureAwait(false))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Comment comment = new Comment();
                            comment.CommentKey = reader.GetInt32("CommentKey");
                            comment.CommentGuid = reader.GetGuid("CommentGuid");
                            comment.ParentCommentKey = reader["ParentCommentKey"] == DBNull.Value ? null : (int?)reader["ParentCommentKey"];// "Blog Title " + i,
                            comment.Content = reader.GetString("Content");// "Amazing blog and its content",
                            comment.PostKey = reader["PostKey"] == DBNull.Value ? 0 : (int)reader["PostKey"]; 
                            comment.CreatedAt = reader.GetDateTime("CreatedAt");// "This is an amazing blog and is very tremendous looking and was when created broke all the records and still it is continuing. When ever there is an event there will be an amaxing instances",
                            //comment.CreatedBy = reader.GetInt32("CreatedBy");// "This is an amazing blog and is very tremendous looking and was when created broke all the records and still it is continuing. When ever there is an event there will be an amaxing instances",
                            comment.UpdatedAt = reader.GetDateTime("UpdatedAt");// "This is an amazing blog and is very tremendous looking and was when created broke all the records and still it is continuing. When ever there is an event there will be an amaxing instances",
                            comment.UpdatedBy = new User()
                            {
                                Name = "Awesome blogger user",
                                About = "Something amazing about this user"
                            };
                            comments.Add(comment);
                        }
                    }
                }
            }
            return comments;
        }

        public async Task<IEnumerable<Post>> GetPosts(ApplicationContext context, int StartPage, int NumberOfPage, int NumberOfRecordPerPage)
        {
            List<Post> posts = new List<Post>();
            using (SqlCommand command = this.helper.GetCommand("SELECT PostKey, PostGuid, Title, SubTitle, BrowserTitle, AuthorKey, Url, SortUrl, MainContentImageUrl, MainContentImageSubtitle, Content, CategoryKey, IsPublished, IsActive, IsDeleted, BlogKey, Views, Votes, Previous, Next, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy FROM [dbo].[Post]"))
            {
                using (DbDataReader reader = await this.helper.ExecuteReaderAsync(command).ConfigureAwait(false))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Post post = new Post();
                            post.PostKey = reader.GetInt32("PostKey");
                            post.BlogKey = reader["BlogKey"] == DBNull.Value ? 0 : (int)reader["BlogKey"];
                            post.Title = reader.GetString("Title");// "Blog Title " + i,
                            post.SubTitle = reader.GetString("SubTitle");// "Amazing blog and its content",
                            post.MainContentImageUrl = reader["MainContentImageUrl"] == DBNull.Value ? null : context.BaseUrl + (string)reader["MainContentImageUrl"];// "http://localhost:4200/assets/images/coverimage.jpg",
                            post.Content = reader.GetString("Content");// "This is an amazing blog and is very tremendous looking and was when created broke all the records and still it is continuing. When ever there is an event there will be an amaxing instances",
                            post.Author = new User()
                            {
                                Name = "Awesome blogger user",
                                About = "Something amazing about this user"
                            };
                            post.Votes = reader.GetInt32("Votes");// 8987
                            posts.Add(post);
                        }
                    }
                }
            }
            return posts;
        }

        public async Task<IEnumerable<Post>> GetPosts(ApplicationContext context, int UserId, int StartPage, int NumberOfPage, int NumberOfRecordPerPage)
        {

            List<Post> posts = new List<Post>();
            using (SqlCommand command = this.helper.GetCommand("SELECT PostKey, PostGuid, Title, SubTitle, BrowserTitle, AuthorKey, Url, SortUrl, MainContentImageUrl, MainContentImageSubtitle, Content, CategoryKey, IsPublished, IsActive, IsDeleted, BlogKey, Views, Votes, Previous, Next, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy FROM [dbo].[Post]"))
            {
                using (DbDataReader reader = await this.helper.ExecuteReaderAsync(command).ConfigureAwait(false))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Post post = new Post();
                            post.PostKey = reader.GetInt32("PostKey");
                            post.BlogKey = reader["BlogKey"] == DBNull.Value ? 0 : (int)reader["BlogKey"];
                            //blog.Url = reader.GetString("Url");// "http://localhost:4200/blog/987979/the%2Bfirst%2Bpart%2Bis%2Bthe%2Basdf",
                            post.Title = reader.GetString("Title");// "Blog Title " + i,
                            post.SubTitle = reader.GetString("SubTitle");// "Amazing blog and its content",
                            post.MainContentImageUrl = reader["MainContentImageUrl"] == DBNull.Value ? null : context.BaseUrl + (string)reader["MainContentImageUrl"];// "http://localhost:4200/assets/images/coverimage.jpg",
                            post.Content = reader.GetString("Content");// "This is an amazing blog and is very tremendous looking and was when created broke all the records and still it is continuing. When ever there is an event there will be an amaxing instances",
                            post.Author = new User()
                            {
                                Name = "Awesome blogger user",
                                About = "Something amazing about this user"
                            };
                            post.Votes = reader.GetInt32("Votes");// 8987
                            posts.Add(post);
                        }
                    }
                }
            }
            return posts;
        }

        public async Task<Post> GetPost(ApplicationContext context, int Id)
        {
            Post post = new Post();
            using (SqlCommand command = this.helper.GetCommand("SELECT PostKey, PostGuid, Title, SubTitle, BrowserTitle, AuthorKey, Url, SortUrl, MainContentImageUrl, MainContentImageSubtitle, Content, CategoryKey, IsPublished, IsActive, IsDeleted, BlogKey, Views, Votes, Previous, Next, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy FROM [dbo].[Post] WHERE PostKey = '" + Id + "'"))
            {
                using (DbDataReader reader = await this.helper.ExecuteReaderAsync(command).ConfigureAwait(false))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            post.PostKey = reader.GetInt32("PostKey");
                            post.BlogKey = reader["BlogKey"] == DBNull.Value ? 0 : (int)reader["BlogKey"];
                            //blog.Url = reader.GetString("Url");// "http://localhost:4200/blog/987979/the%2Bfirst%2Bpart%2Bis%2Bthe%2Basdf",
                            post.Title = reader.GetString("Title");// "Blog Title " + i,
                            post.SubTitle = reader.GetString("SubTitle");// "Amazing blog and its content",
                            post.MainContentImageUrl = reader["MainContentImageUrl"] == DBNull.Value ? null : context.BaseUrl + (string)reader["MainContentImageUrl"];// "http://localhost:4200/assets/images/coverimage.jpg",
                            post.Content = reader.GetString("Content");// "This is an amazing blog and is very tremendous looking and was when created broke all the records and still it is continuing. When ever there is an event there will be an amaxing instances",
                            post.Author = new User()
                            {
                                Name = "Awesome blogger user",
                                About = "Something amazing about this user"
                            };
                            post.Votes = reader.GetInt32("Votes");// 8987
                        }
                    }
                }
            }
            return post;
        }

        public async Task<Comment> UpdateComment(ApplicationContext context, int id, string commentContent)
        {
            Comment comment = new Comment();
            comment.CommentKey = id;
            comment.Content = commentContent;
            return comment;
        }

        public bool UpdateInformation(ApplicationContext context, int Id, string PostContent)
        {
            return true;
        }

        public bool UpdateTitle(ApplicationContext context, int Id, string Title)
        {
            return true;
        }
    }
}
