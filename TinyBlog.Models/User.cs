using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TinyBlog.Models
{
    public class User
    {
        public int UserKey { get; set; }
        public Guid UserGuid { get; set; }
        public string UserID { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Email { get; set; }
        private string _password;
        public string Password { get { return _password; } set { _password = value; } }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string About { get; set; }
        public List<Category> Categories { get; set; }
        public string ImageUrl { get; set; }
        public string ProfileUrl { get {
                return "user/" + UserKey + "/" + UserID;
            } }
        public bool IsActive { get; set; } = true;
        public int Vote { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public DateTime? LastActive { get; set; }
        public int BlogsCount { get; set; }
        public int PostsCount { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public DateTime? CreatedAt { get; set; }
        public User CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public User UpdatedBy { get; set; }
    }

    public class AuthenticatedUser: User
    {
        public string Token { get; set; }
    }
}
