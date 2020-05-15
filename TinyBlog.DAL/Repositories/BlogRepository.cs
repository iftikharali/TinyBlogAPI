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
    public class BlogRepository : IBlogRepository
    {
        private IDALHelper helper;
        public BlogRepository(IDALHelper helper)
        {
            this.helper = helper;
        }

        public async Task<Blog> CreateBlog(ApplicationContext context, Blog blog)
        {
            using (SqlCommand command = this.helper.GetCommand(@"Insert into [dbo].[Blog]
                                                    (BlogGuid,Title,SubTitle,MainContentImageUrl,MainContentImageSubtitle,BrowserTitle,OwnerKey,Url,SortUrl,Content,CreatedBy,UpdatedBy) 
                                                  values(@BlogGuid,@Title,@SubTitle,@MainContentImageUrl,@MainContentImageSubtitle,@BrowserTitle,@OwnerKey,@Url,@SortUrl,@Content,@CreatedBy,@UpdatedBy)"))
            {
                command.Parameters.AddWithValue("@BlogGuid", (object)blog.BlogGuid ?? DBNull.Value);
                command.Parameters.AddWithValue("@Title", (object)blog.Title ?? DBNull.Value);
                command.Parameters.AddWithValue("@SubTitle", (object)blog.SubTitle ?? DBNull.Value);
                command.Parameters.AddWithValue("@MainContentImageUrl", (object)blog.MainContentImageUrl ?? DBNull.Value);
                command.Parameters.AddWithValue("@MainContentImageSubtitle", (object)blog.MainContentImageSubtitle ?? DBNull.Value);
                command.Parameters.AddWithValue("@BrowserTitle", (object)blog.BrowserTitle ?? DBNull.Value);
                command.Parameters.AddWithValue("@OwnerKey", context.UserKey);
                command.Parameters.AddWithValue("@Url", (object)blog.Url ?? DBNull.Value);
                command.Parameters.AddWithValue("@SortUrl", (object)blog.SortUrl ?? DBNull.Value);
                command.Parameters.AddWithValue("@Content", (object)blog.Content ?? DBNull.Value);
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
            return blog;
        }

        public bool DeleteBlog(int Id)
        {
            return true;
        }

        public async Task<IEnumerable<Blog>> GetBlogs(ApplicationContext context, int StartPage, int NumberOfPage, int NumberOfRecordPerPage)
        {
            List<Blog> blogs = new List<Blog>();

            using (SqlCommand command = this.helper.GetCommand("select [BlogKey], [BlogGuid], [Title], [SubTitle], [MainContentImageUrl], [MainContentImageSubtitle], [BrowserTitle], [OwnerKey], [Url], [SortUrl], [Content], [IsActive], [IsDeleted], [Votes], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy] from[dbo].[Blog]"))
            {
                using (DbDataReader reader = await this.helper.ExecuteReaderAsync(command).ConfigureAwait(false))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Blog blog = new Blog();
                            blog.BlogKey = reader.GetInt32("BlogKey");
                            //blog.Url = reader.GetString("Url");// "http://localhost:4200/blog/987979/the%2Bfirst%2Bpart%2Bis%2Bthe%2Basdf",
                            blog.Title = reader.GetString("Title");// "Blog Title " + i,
                            blog.SubTitle = reader.GetString("SubTitle");// "Amazing blog and its content",
                            blog.MainContentImageUrl = reader["MainContentImageUrl"] == DBNull.Value ? null : context.BaseUrl + (string)reader["MainContentImageUrl"];// "http://localhost:4200/assets/images/coverimage.jpg",
                            blog.Content = reader.GetString("Content");// "This is an amazing blog and is very tremendous looking and was when created broke all the records and still it is continuing. When ever there is an event there will be an amaxing instances",
                            blog.Owner = new User()
                            {
                                Name = "Awesome blogger user",
                                About = "Something amazing about this user"
                            };
                            blog.Votes = reader.GetInt32("Votes");// 8987
                            blogs.Add(blog);
                        }
                    }
                }
            }

            return blogs;
        }

        public async Task<IEnumerable<Blog>> GetBlogs(ApplicationContext context,int UserId, int StartPage, int NumberOfPage, int NumberOfRecordPerPage)
        {
            List<Blog> blogs = new List<Blog>();

            using (SqlCommand command = this.helper.GetCommand("SELECT [BlogKey], [BlogGuid], [Title], [SubTitle], [MainContentImageUrl], [MainContentImageSubtitle], [BrowserTitle], [OwnerKey], [Url], [SortUrl], [Content], [IsActive], [IsDeleted], [Votes], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy] FROM [dbo].[Blog]"))
            {
                using (DbDataReader reader = await this.helper.ExecuteReaderAsync(command).ConfigureAwait(false))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Blog blog = new Blog();
                            blog.BlogKey = reader.GetInt32("BlogKey");
                            //blog.Url = reader.GetString("Url");// "http://localhost:4200/blog/987979/the%2Bfirst%2Bpart%2Bis%2Bthe%2Basdf",
                            blog.Title = reader.GetString("Title");// "Blog Title " + i,
                            blog.SubTitle = reader.GetString("SubTitle");// "Amazing blog and its content",
                            blog.MainContentImageUrl = reader["MainContentImageUrl"] == DBNull.Value ? null : context.BaseUrl + (string)reader["MainContentImageUrl"];// "http://localhost:4200/assets/images/coverimage.jpg",
                            blog.Content = reader.GetString("Content");// "This is an amazing blog and is very tremendous looking and was when created broke all the records and still it is continuing. When ever there is an event there will be an amaxing instances",
                            blog.Owner = new User()
                            {
                                Name = "Awesome blogger user",
                                About = "Something amazing about this user"
                            };
                            blog.Votes = reader.GetInt32("Votes");// 8987
                            blogs.Add(blog);
                        }
                    }
                }
            }

            return blogs;
        }

        public async Task<Blog> GetBlog(ApplicationContext context,int Id)
        {
            Blog blog = new Blog();
            using (SqlCommand command = this.helper.GetCommand("SELECT [BlogKey], [BlogGuid], [Title], [SubTitle], [MainContentImageUrl], [MainContentImageSubtitle], [BrowserTitle], [OwnerKey], [Url], [SortUrl], [Content], [IsActive], [IsDeleted], [Votes], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy] FROM [dbo].[Blog] WHERE BlogKey = '" + Id + "'"))
            {
                using (DbDataReader reader = await this.helper.ExecuteReaderAsync(command).ConfigureAwait(false))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            blog.BlogKey = reader.GetInt32("BlogKey");
                            //blog.Url = reader.GetString("Url");// "http://localhost:4200/blog/987979/the%2Bfirst%2Bpart%2Bis%2Bthe%2Basdf",
                            blog.Title = reader.GetString("Title");// "Blog Title " + i,
                            blog.SubTitle = reader.GetString("SubTitle");// "Amazing blog and its content",
                            blog.MainContentImageUrl = reader["MainContentImageUrl"] == DBNull.Value ? null : context.BaseUrl + (string)reader["MainContentImageUrl"];// "http://localhost:4200/assets/images/coverimage.jpg",
                            blog.Content = reader.GetString("Content");// "This is an amazing blog and is very tremendous looking and was when created broke all the records and still it is continuing. When ever there is an event there will be an amaxing instances",
                            blog.Owner = new User()
                            {
                                Name = "Awesome blogger user",
                                About = "Something amazing about this user"
                            };
                            blog.Votes = reader.GetInt32("Votes");// 8987
                        }
                    }
                }
            }
            return blog;
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
