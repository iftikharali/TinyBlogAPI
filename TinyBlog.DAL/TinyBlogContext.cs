﻿using System;
using System.Collections.Generic;
using System.Text;
using TinyBlog.Models;

namespace TinyBlog.DAL
{
    public class TinyBlogContext
    {
        List<User> Users { get; set; }
        List<Blog> Blogs { get; set; }
        List<Comment> Comments { get; set; }

        public bool DeleteUser(User user)
        {
            //delete user from Users list using User
            return true;
        }

        public bool DeleteUser(Guid userId)
        {
            return true;
        }

        public User GetUser(int id)
        {
            User user = new User();
            user.ID = id;
            user.UserID = Guid.NewGuid();
            user.Name = "Name";
            return user;
        }

        public User CreateUser(User user)
        {
            User newUser = new User();
            Random r = new Random();
            newUser.ID = r.Next();
            newUser.UserID = Guid.NewGuid();
            newUser.Name = "Name";
            return newUser;
        }

        public User GetUser(Guid userId)
        {
            User user = new User();
            user.UserID = userId;
            user.Name = "Name";
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            List<User> users = new List<User>();
            for(int i = 0; i < 5; i++)
            {
                User user = new User();
                user.UserID = Guid.NewGuid();
                user.Name = "Name"+(i+1);
                user.Email = "email" + (i + 1) + "@test.com";
                user.Password = "Password@123";
                users.Add(user);
            }
            return users;
        }

        public bool DeleteUser(int id)
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
