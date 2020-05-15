using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using TinyBlog.DAL.Helpers.Interfaces;
using TinyBlog.DAL.Interfaces;
using TinyBlog.Models;

namespace TinyBlog.DAL
{
    public class TinyBlogContext:ITinyBlogContext
    {
        List<User> Users { get; set; }
        List<Blog> Blogs { get; set; }
        List<Comment> Comments { get; set; }
        private IDALHelper helper;

        public TinyBlogContext(IDALHelper helper)
        {
            this.helper = helper;
        }
        public bool DeleteUser(User user)
        {
            //delete user from Users list using User
            return true;
        }

        public bool DeleteUser(Guid userId)
        {
            return true;
        }

        public async Task<User> GetUser(int id)
        {
           
                User user = new User();
                SqlCommand command = this.helper.GetCommand("select * from [dbo].[User]");
                using (DbDataReader reader = await this.helper.ExecuteReaderAsync(command).ConfigureAwait(false))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            user.UserKey = (int)reader.GetInt32("UserKey");
                            user.UserID = reader.GetString("UserId");
                            user.UserGuid = reader.GetGuid("UserGuid");
                            user.Name = reader.GetString("Name");
                            user.About = reader.GetString("About");// Fusce augue nunc, ornare in risus at, porttitor molestie lectus. Aliquam a fermentum nulla. Sed molestie tristique leo eget lobortis. Pellentesque molestie pulvinar massa laoreet tristique. Cras convallis ac ante vitae lacinia. Nunc imperdiet elementum congue. In hac habitasse platea dictumst. Suspendisse iaculis bibendum dolor vitae blandit. Phasellus ac diam placerat, tempor mi ut, luctus dolor. Nulla facilisi.";
                            user.ImageUrl = reader.GetString("ImageUrl");// "http://localhost:4200/assets/images/profile.jpg";
                            //user.ProfileUrl = reader.GetString("ProfileUrl");// "http://localhost:4200/user/" + user.UserKey + "/" + user.UserID;
                            user.BlogsCount = (int)reader.GetInt32("BlogCount");
                            user.PostsCount = (int)reader.GetInt32("PostCount");// 23423;
                            user.Vote = reader.GetInt32("Vote");
                            user.Email = reader.GetString("Email");// "email1@test.com";
                            user.Website = reader.GetString("Website");// "https://www.testing.com";
                            user.Phone = reader.GetString("Phone");
                            user.DateOfJoining = reader.GetDateTime("DateOfJoining");
                            user.LastActive = reader["LastActive"]== DBNull.Value ? null : (DateTime?)reader["LastActive"];
                        }
                    }
                }

            user.Categories = new List<Category>()
            {
                new Category()
                {
                    Name = "Amazon Web Service",
                    PostCount = 2
                },
                new Category()
                {
                    Name = "Comedy",
                    PostCount = 57
                },
                new Category()
                {
                    Name = "Artificial Intelligence",
                    PostCount = 26
                },
                new Category()
                {
                    Name = "Mechanical Engineering",
                    PostCount = 34
                }
            };
            //user.DateOfJoining = DateTime.Now.AddMonths(-20);
            //user.LastActive = DateTime.Now.AddMinutes(-10);
            return user;

            
        }

        public User GetLoggedInUser(int id)
        {
            User user = new User();
            user.UserKey = id;
            user.UserGuid = Guid.NewGuid();
            user.UserID = "user121";
            user.Name = "Name";
            user.About = "Fusce augue nunc, ornare in risus at, porttitor molestie lectus. Aliquam a fermentum nulla. Sed molestie tristique leo eget lobortis. Pellentesque molestie pulvinar massa laoreet tristique. Cras convallis ac ante vitae lacinia. Nunc imperdiet elementum congue. In hac habitasse platea dictumst. Suspendisse iaculis bibendum dolor vitae blandit. Phasellus ac diam placerat, tempor mi ut, luctus dolor. Nulla facilisi.";
            user.ImageUrl = "http://localhost:4200/assets/images/profile.jpg";
            //user.ProfileUrl = "http://localhost:4200/user/" + user.UserKey + "/" + user.UserID;
            user.BlogsCount = 23;
            user.PostsCount = 23423;
            user.Vote = 23423;
            user.Email = "email1@test.com";
            user.Website = "https://www.testing.com";
            user.Phone = "+91 - 0123456789";
            user.Categories = new List<Category>()
            {
                new Category()
                {
                    Name = "Amazon Web Service",
                    PostCount = 2
                },
                new Category()
                {
                    Name = "Comedy",
                    PostCount = 57
                },
                new Category()
                {
                    Name = "Artificial Intelligence",
                    PostCount = 26
                },
                new Category()
                {
                    Name = "Mechanical Engineering",
                    PostCount = 34
                }
            };
            user.DateOfJoining = DateTime.Now.AddMonths(-20);
            user.LastActive = DateTime.Now.AddMinutes(-10);
            return user;
        }

        public User CreateUser(User user)
        {
            User newUser = new User();
            Random r = new Random();
            newUser.UserKey = (int)r.Next();
            newUser.UserGuid = Guid.NewGuid();
            newUser.Name = "Name";
            return newUser;
        }

        public User GetUser(Guid userGuid)
        {
            User user = new User();
            user.UserGuid = userGuid;
            user.Name = "Name";
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            List<User> users = new List<User>();
            for(int i = 0; i < 5; i++)
            {
                User user = new User();
                user.UserID = "user12" + (i + 1);
                user.UserGuid = Guid.NewGuid();
                user.Name = "Name"+(i+1);
                user.Email = "email" + (i + 1) + "@test.com";
                user.Password = "Password@123";
                //user.ProfileUrl = "http://localhost:4200/user/" + user.UserKey + "/" + user.UserID;
                users.Add(user);
            }
            return users;
        }

        public bool DeleteUser(int UserKey)
        {
            return true;
        }

        public bool UpdateUserEmail(string email)
        {
            return true;
        }

        public bool UpdateUserName(string name)
        {
            return true;
        }

        public bool UpdateUserPassword(string password)
        {
            return true;
        }

        public bool UpdateUserPhone(string phoneNumber)
        {
            return true;
        }
    }
}
