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

            using (SqlCommand command = this.helper.GetCommand("select [BlogKey], [BlogGuid], [Title], [SubTitle], [MainContentImageUrl], [MainContentImageSubtitle], [BrowserTitle], [OwnerKey], OwnerName, OwnerGuid, OwnerAbout, ImageUrl,[Url], [SortUrl], [Content], [IsActive], [IsDeleted], [Recommend],[SubscriberCount], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy] from[dbo].[Blog_View]"))
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
                                Name = reader["OwnerName"] == DBNull.Value ? null : (string)reader["OwnerName"],
                                About = reader["OwnerAbout"] == DBNull.Value ? null : (string)reader["OwnerAbout"],
                                UserGuid = reader.GetGuid("OwnerGuid"),
                                ImageUrl = reader["ImageUrl"] == DBNull.Value ? null : context.BaseUrl + (string)reader["ImageUrl"]
                            };
                            blog.Recommend = reader.GetInt32("Recommend");// 8987
                            blog.SubscriberCount = reader.GetInt32("SubscriberCount");
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

            using (SqlCommand command = this.helper.GetCommand("SELECT [BlogKey], [BlogGuid], [Title], [SubTitle], [MainContentImageUrl], [MainContentImageSubtitle], [BrowserTitle], [OwnerKey], OwnerName, OwnerGuid, OwnerAbout, ImageUrl,[Url], [SortUrl], [Content], [IsActive], [IsDeleted], [Recommend],[SubscriberCount], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy] FROM [dbo].[Blog_View]"))
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
                                Name = reader["OwnerName"] == DBNull.Value ? null : (string)reader["OwnerName"],
                                About = reader["OwnerAbout"] == DBNull.Value ? null : (string)reader["OwnerAbout"],
                                UserGuid = reader.GetGuid("OwnerGuid"),
                                ImageUrl = reader["ImageUrl"] == DBNull.Value ? null : context.BaseUrl + (string)reader["ImageUrl"]
                            };
                            blog.Recommend = reader.GetInt32("Recommend");// 8987
                            blog.SubscriberCount = reader.GetInt32("SubscriberCount");
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
            using (SqlCommand command = this.helper.GetCommand("SELECT [BlogKey], [BlogGuid], [Title], [SubTitle], [MainContentImageUrl], [MainContentImageSubtitle], [BrowserTitle], [OwnerKey], OwnerName, OwnerGuid, OwnerAbout, ImageUrl,[Url], [SortUrl], [Content], [IsActive], [IsDeleted], [Recommend],[SubscriberCount], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy] FROM [dbo].[Blog_View] WHERE BlogKey = '" + Id + "'"))
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
                                Name = reader["OwnerName"] == DBNull.Value ? null : (string)reader["OwnerName"],
                                About = reader["OwnerAbout"] == DBNull.Value ? null : (string)reader["OwnerAbout"],
                                UserGuid = reader.GetGuid("OwnerGuid"),
                                ImageUrl = reader["ImageUrl"] == DBNull.Value ? null : context.BaseUrl + (string)reader["ImageUrl"]
                            };
                            blog.Recommend = reader.GetInt32("Recommend");// 8987
                            blog.SubscriberCount = reader.GetInt32("SubscriberCount");
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

        public async Task<bool> Subscribe(ApplicationContext context, int blogKey)
        {
            using (SqlCommand command = this.helper.GetCommand(@"Insert into [dbo].[Counter]
                                                    (CounterGuid, EntityKey, EntityType,CounterType, Count, CreatedBy, UpdatedBy) 
                                                  values(@CounterGuid, @EntityKey, @EntityType, @CounterType, @Count,  @CreatedBy, @UpdatedBy)"))
            {


                command.Parameters.AddWithValue("@CounterGuid", Guid.NewGuid());
                command.Parameters.AddWithValue("@EntityKey", blogKey);
                command.Parameters.AddWithValue("@EntityType", "blog");
                command.Parameters.AddWithValue("@CounterType", "Subscribe");
                command.Parameters.AddWithValue("@Count", 1);
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
                    return false;
                }
            }
            return true;
        }
        public async Task<bool> Recommend(ApplicationContext context, int blogKey)
        {
            using (SqlCommand command = this.helper.GetCommand(@"Insert into [dbo].[Counter]
                                                    (CounterGuid, EntityKey, EntityType,CounterType, Count, CreatedBy, UpdatedBy) 
                                                  values(@CounterGuid, @EntityKey, @EntityType, @CounterType, @Count,  @CreatedBy, @UpdatedBy)"))
            {


                command.Parameters.AddWithValue("@CounterGuid", Guid.NewGuid());
                command.Parameters.AddWithValue("@EntityKey", blogKey);
                command.Parameters.AddWithValue("@EntityType", "blog");
                command.Parameters.AddWithValue("@CounterType", "Recommend");
                command.Parameters.AddWithValue("@Count", 1);
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
                    return false;
                }
            }
            return true;
        }
    }
}
