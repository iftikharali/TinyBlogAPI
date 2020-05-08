using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TinyBlog.DAL;
using TinyBlog.DAL.Helpers.Interfaces;
using TinyBlog.DAL.Interfaces;
using TinyBlog.Models;
using TinyBlog.Repositories.Interfaces;

namespace TinyBlog.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IDALHelper helper;
        public UserRepository(IDALHelper helper)
        {
            this.helper = helper;
        }
        
        public async Task<User> CreateUser(ApplicationContext context, User user)
        {
            /*SqlCommand command = this.helper.GetCommand(@"INSERT INTO [dbo].[User]([UserID], [Name], [DateOfBirth], [Email], [Password], [Phone], [Website],
                                                                                   [About], [ImageUrl], [ProfileUrl], [IsActive], [Vote], [DateOfJoining],
                                                                               [LastActive], [BlogCount], [PostCount], [CreatedAt], [CreatedBy], [UpdatedAt], [UpdatedBy])
                                                                             Values(@UserID, @Name, @DateOfBirth, @Email, @Password, @Phone, @Website, 
                                                                    @About, @ImageUrl, @ProfileUrl, @IsActive, @Vote, @DateOfJoining, 
                                                                    @LastActive, @BlogCount, @PostCount, @CreatedAt, @CreatedBy, @UpdatedAt, @UpdatedBy
                                                            )");*/

            SqlCommand command = this.helper.GetCommand(@"Insert into [dbo].[User]
                                                        (CreatedBy,UpdatedBy,DateOfJoining,LastActive,Phone,Website,About,ImageUrl,ProfileUrl,UserId,Name,DateOfBirth,Email,Password,IsActive,Vote,BlogCount,PostCount,CreatedAt,UpdatedAt) 
                                                  values(@CreatedBy,@UpdatedBy,@DateOfJoining,@LastActive,@Phone,@Website,@About,@ImageUrl,@ProfileUrl,@UserId,@Name,@DateOfBirth,@Email,@Password,@IsActive,@Vote,@BlogCount,@PostCount,@CreatedAt,@UpdatedAt)");
            user.UserID = user.Email;
            //command.Parameters.AddWithValue("@UserKey",user.UserKey);
            //command.Parameters.AddWithValue("@UserGuid", user.);
            //command.Parameters.AddWithValue("@UserID", (object)user.UserID??DBNull.Value);
            //command.Parameters.AddWithValue("@Name", (object)user.Name??DBNull.Value);
            //command.Parameters.AddWithValue("@DateOfBirth", (object)user.DateOfBirth??DBNull.Value);
            //command.Parameters.AddWithValue("@Email", (object)user.Email??DBNull.Value);
            //command.Parameters.AddWithValue("@Password", (object)user.Password??DBNull.Value);
            command.Parameters.AddWithValue("@Phone", (object)user.Phone ?? DBNull.Value);
            command.Parameters.AddWithValue("@Website", (object)user.Website??DBNull.Value);
             command.Parameters.AddWithValue("@About", (object)user.About??DBNull.Value);
             command.Parameters.AddWithValue("@ImageUrl", (object)user.ImageUrl??DBNull.Value);
             command.Parameters.AddWithValue("@ProfileUrl", (object)user.ProfileUrl??DBNull.Value);
             //command.Parameters.AddWithValue("@IsActive", (object)user.IsActive??DBNull.Value);
             //command.Parameters.AddWithValue("@Vote", (object)user.Vote??DBNull.Value);
             command.Parameters.AddWithValue("@DateOfJoining", DateTime.Now);
             command.Parameters.AddWithValue("@LastActive", DateTime.Now);
             //command.Parameters.AddWithValue("@BlogCount", 0);
             //command.Parameters.AddWithValue("@PostCount", 0);
             //command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
             command.Parameters.AddWithValue("@CreatedBy", context.UserKey);
             //command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
             command.Parameters.AddWithValue("@UpdatedBy", context.UserKey);

            command.Parameters.AddWithValue("@UserId", user.UserID);
           command.Parameters.AddWithValue("@Name", user.Name);
           command.Parameters.AddWithValue("@DateOfBirth",user.DateOfBirth);
           command.Parameters.AddWithValue("@Email", user.Email);
           command.Parameters.AddWithValue("@Password", user.Password);
           command.Parameters.AddWithValue("@IsActive", true);
           command.Parameters.AddWithValue("@Vote", 0);
           command.Parameters.AddWithValue("@BlogCount", 0);
           command.Parameters.AddWithValue("@PostCount", 0);
           command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
           command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
            try
            {
                 int IsQuerySucess = await this.helper.ExecuteNonQueryAsync(command).ConfigureAwait(false);
             } catch(Exception ex)
             {
                 string s = ex.Message;
                 string st = s;
             }
             /*
             using (DbDataReader reader = await this.helper.ExecuteReaderAsync(command).ConfigureAwait(false))
             {
                 if (reader.HasRows)
                 {
                     while (reader.Read())
                     {
                         user.UserKey = (uint)reader.GetInt32("UserKey");
                         user.UserID = reader.GetString("UserId");
                         user.UserGuid = reader.GetGuid("UserGuid");
                         user.Name = reader.GetString("Name");
                         user.About = reader.GetString("About");// Fusce augue nunc, ornare in risus at, porttitor molestie lectus. Aliquam a fermentum nulla. Sed molestie tristique leo eget lobortis. Pellentesque molestie pulvinar massa laoreet tristique. Cras convallis ac ante vitae lacinia. Nunc imperdiet elementum congue. In hac habitasse platea dictumst. Suspendisse iaculis bibendum dolor vitae blandit. Phasellus ac diam placerat, tempor mi ut, luctus dolor. Nulla facilisi.";
                         user.ImageUrl = reader.GetString("ImageUrl");// "http://localhost:4200/assets/images/profile.jpg";
                         user.ProfileUrl = reader.GetString("ProfileUrl");// "http://localhost:4200/user/" + user.UserKey + "/" + user.UserID;
                         user.BlogsCount = (uint)reader.GetInt32("BlogCount");
                         user.PostsCount = (uint)reader.GetInt32("PostCount");// 23423;
                         user.Vote = reader.GetInt32("Vote");
                         user.Email = reader.GetString("Email");// "email1@test.com";
                         user.Website = reader.GetString("Website");// "https://www.testing.com";
                         user.Phone = reader.GetString("Phone");
                         user.DateOfJoining = reader.GetDateTime("DateOfJoining");
                         user.LastActive = reader["LastActive"] == DBNull.Value ? null : (DateTime?)reader["LastActive"];
                     }
                 }
             }*/
           /* SqlConnection connection = new SqlConnection(@"Data Source=A2ML32669\SQLEXPRESS;Initial Catalog=TinyBlog;Integrated Security=True;MultipleActiveResultSets=True");
            //string query = "INSERT INTO Products (Name, Price, Date) VALUES(@Name, @Price, @Date)";
            SqlCommand cmd = new SqlCommand(query,connection);

            //Pass values to Parameters
            cmd.Parameters.AddWithValue("@Name", "USB Keyboard");
            cmd.Parameters.AddWithValue("@Price", null??DBNull.Value);
            cmd.Parameters.AddWithValue("@Date", "25 May 2017");

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                string str = "Error Generated. Details: " + e.ToString();
            }
            finally
            {
                connection.Close();
            }*/
            return user;
        }

        public bool DeleteUser(User user)
        {
            return true; ;
        }

        public bool DeleteUser(Guid UserId)
        {
            return true;// _context.DeleteUser(UserId);
        }

        public bool DeleteUser(uint Id)
        {
            return true;// _context.DeleteUser(Id);
        }

        public User GetLoggedInUser(uint id)
        {
            return null;// _context.GetLoggedInUser(id);
        }

        public async Task<User> GetUser(uint Id)
        {
            User user = new User();
            SqlCommand command = this.helper.GetCommand("select * from [dbo].[User] where UserKey = '"+Id+"'");
            using (DbDataReader reader = await this.helper.ExecuteReaderAsync(command).ConfigureAwait(false))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.UserKey = (uint)reader.GetInt32("UserKey");
                        user.UserID = reader.GetString("UserId");
                        user.UserGuid = reader.GetGuid("UserGuid");
                        user.Name = reader.GetString("Name");
                        user.Password = reader.GetString("Password");
                        user.About = reader["About"] == DBNull.Value ? null : (string)reader["About"];// Fusce augue nunc, ornare in risus at, porttitor molestie lectus. Aliquam a fermentum nulla. Sed molestie tristique leo eget lobortis. Pellentesque molestie pulvinar massa laoreet tristique. Cras convallis ac ante vitae lacinia. Nunc imperdiet elementum congue. In hac habitasse platea dictumst. Suspendisse iaculis bibendum dolor vitae blandit. Phasellus ac diam placerat, tempor mi ut, luctus dolor. Nulla facilisi.";
                        user.ImageUrl = reader["ImageUrl"] == DBNull.Value ? null : (string)reader["ImageUrl"];// "http://localhost:4200/assets/images/profile.jpg";
                        //user.ProfileUrl = reader["ProfileUrl"] == DBNull.Value ? null : (string)reader["ProfileUrl"];// "http://localhost:4200/user/" + user.UserKey + "/" + user.UserID;
                        user.BlogsCount = (uint)reader.GetInt32("BlogCount");
                        user.PostsCount = (uint)reader.GetInt32("PostCount");// 23423;
                        user.Vote = reader.GetInt32("Vote");
                        user.Email = reader.GetString("Email");// "email1@test.com";
                        user.Website = reader["Website"] == DBNull.Value ? null : (string)reader["Website"];// "https://www.testing.com";
                        user.Phone = reader["Phone"] == DBNull.Value ? null : (string)reader["Phone"];
                        user.DateOfJoining = reader["DateOfJoining"] == DBNull.Value ? null : (DateTime?)reader["DateOfJoining"];
                        user.LastActive = reader["LastActive"] == DBNull.Value ? null : (DateTime?)reader["LastActive"];
                    }
                }
            }
            return user;
        }

        public async Task<User> GetUser(Guid UserId)
        {
            User user = new User();
            SqlCommand command = this.helper.GetCommand("select * from [dbo].[User] where UserGuid = '" + UserId + "'");
            using (DbDataReader reader = await this.helper.ExecuteReaderAsync(command).ConfigureAwait(false))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.UserKey = (uint)reader.GetInt32("UserKey");
                        user.UserID = reader.GetString("UserId");
                        user.UserGuid = reader.GetGuid("UserGuid");
                        user.Name = reader.GetString("Name");
                        user.Password = reader.GetString("Password");
                        user.About = reader["About"] == DBNull.Value ? null : (string)reader["About"];// Fusce augue nunc, ornare in risus at, porttitor molestie lectus. Aliquam a fermentum nulla. Sed molestie tristique leo eget lobortis. Pellentesque molestie pulvinar massa laoreet tristique. Cras convallis ac ante vitae lacinia. Nunc imperdiet elementum congue. In hac habitasse platea dictumst. Suspendisse iaculis bibendum dolor vitae blandit. Phasellus ac diam placerat, tempor mi ut, luctus dolor. Nulla facilisi.";
                        user.ImageUrl = reader["ImageUrl"] == DBNull.Value ? null : (string)reader["ImageUrl"];// "http://localhost:4200/assets/images/profile.jpg";
                        //user.ProfileUrl = reader["ProfileUrl"] == DBNull.Value ? null : (string)reader["ProfileUrl"];// "http://localhost:4200/user/" + user.UserKey + "/" + user.UserID;
                        user.BlogsCount = (uint)reader.GetInt32("BlogCount");
                        user.PostsCount = (uint)reader.GetInt32("PostCount");// 23423;
                        user.Vote = reader.GetInt32("Vote");
                        user.Email = reader.GetString("Email");// "email1@test.com";
                        user.Website = reader["Website"] == DBNull.Value ? null : (string)reader["Website"];// "https://www.testing.com";
                        user.Phone = reader["Phone"] == DBNull.Value ? null : (string)reader["Phone"];
                        user.DateOfJoining = reader["DateOfJoining"] == DBNull.Value ? null : (DateTime?)reader["DateOfJoining"];
                        user.LastActive = reader["LastActive"] == DBNull.Value ? null : (DateTime?)reader["LastActive"];
                    }
                }
            }
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            List<User> users = new List<User>();
            SqlCommand command = this.helper.GetCommand("select * from [dbo].[User]");
            using (DbDataReader reader = await this.helper.ExecuteReaderAsync(command).ConfigureAwait(false))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.UserKey = (uint)reader.GetInt32("UserKey");
                        user.UserID = reader.GetString("UserId");
                        user.UserGuid = reader.GetGuid("UserGuid");
                        user.Name = reader.GetString("Name");
                        user.About = reader["About"] == DBNull.Value ? null : (string)reader["About"];// Fusce augue nunc, ornare in risus at, porttitor molestie lectus. Aliquam a fermentum nulla. Sed molestie tristique leo eget lobortis. Pellentesque molestie pulvinar massa laoreet tristique. Cras convallis ac ante vitae lacinia. Nunc imperdiet elementum congue. In hac habitasse platea dictumst. Suspendisse iaculis bibendum dolor vitae blandit. Phasellus ac diam placerat, tempor mi ut, luctus dolor. Nulla facilisi.";
                        user.ImageUrl = reader["ImageUrl"] == DBNull.Value ? null : (string)reader["ImageUrl"];// "http://localhost:4200/assets/images/profile.jpg";
                        //user.ProfileUrl = reader["ProfileUrl"] == DBNull.Value ? null : (string)reader["ProfileUrl"];// "http://localhost:4200/user/" + user.UserKey + "/" + user.UserID;
                        user.BlogsCount = (uint)reader.GetInt32("BlogCount");
                        user.PostsCount = (uint)reader.GetInt32("PostCount");// 23423;
                        user.Vote = reader.GetInt32("Vote");
                        user.Email = reader.GetString("Email");// "email1@test.com";
                        user.Website = reader["Website"] == DBNull.Value ? null : (string)reader["Website"];// "https://www.testing.com";
                        user.Phone = reader["Phone"] == DBNull.Value ? null : (string)reader["Phone"];
                        user.DateOfJoining = reader["DateOfJoining"] == DBNull.Value ? null : (DateTime?)reader["DateOfJoining"];
                        user.LastActive = reader["LastActive"] == DBNull.Value ? null : (DateTime?)reader["LastActive"];

                        users.Add(user);
                    }
                }
            }
            return users;
        }

        public bool UpdateUserEmail(string Email)
        {
            return false;// _context.UpdateUserEmail(Email);
        }

        public bool UpdateUserName(string Name)
        {
            return false;// _context.UpdateUserName(Name);
        }

        public bool UpdateUserPassword(string Password)
        {
            return true;// _context.UpdateUserPassword(Password);
        }

        public bool UpdateUserPhone(string PhoneNumber)
        {
            return true;// _context.UpdateUserPhone(PhoneNumber);
        }
    }
}
