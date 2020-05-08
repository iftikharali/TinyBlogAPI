using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyBlog.Models;
using TinyBlog.Repositories.Interfaces;

namespace TinyBlog.Repositories
{
    public class PostRepository : IPostRepository
    {
        public Comment CreateComment(string commentContent)
        {
            Comment comment = new Comment();
            comment.Content = commentContent;
            return comment;
        }

        public bool CreatePost(Post post)
        {
            return true;
        }

        public bool DeleteComment(uint id)
        {
            return true;
        }

        public bool DeletePost(int Id)
        {
            return true;
        }

        public Comment getComment(uint comment_id)
        {
            return new Comment();
        }

        public IEnumerable<Comment> getComments(uint post_Id)
        {
            List<Comment> comments = new List<Comment>();
            for(uint i =1; i<17; i++)
            {
                comments.Add(new Comment()
                {
                    CommentKey = 123 + i,
                    Content = "This is the " + i + " comment posted for this post and this is a very much interesting post with ",
                    Post = new Post()
                    {
                        PostKey = post_Id
                    },
                    CreatedBy = new User()
                    {

                    },
                    CreatedAt = DateTime.Now.AddDays((double)(-1 *i)).AddMonths((int)(-1 * i))
                });
            }
            return comments;
        }

        public IEnumerable<Post> GetPost(int StartPage, int NumberOfPage, int NumberOfRecordPerPage)
        {
            List<Post> posts = new List<Post>();
            //{
            //    new Post()
            //    {
            //        Title = "First",
            //        Url =  "http://localhost:4200/post/320/blog+title+new+url",
            //        MainContentImageUrl =  "http://localhost:4200/assets/images/blog.jpg",
            //        Excerpt = "First excerpt",
            //        Tags = new List<Tag>(){new Tag() },
            //        Category = new Category() { CategoryKey = 7, Name = "Digital Science" },
            //        Votes = 14

            //    }
            //};
            for (int i = 1; i <= 107; i++)
            {
                posts.Add(new Post()
                {
                    Title = "General Post " + i,
                    SubTitle = "Subtitle of the page and hence",
                    Url = "http://localhost:4200/post/320/blog+title+new+url",
                    MainContentImageUrl = "http://localhost:4200/assets/images/blog.jpg",
                    Excerpt = "Second excerpt " + i,
                    Tags = new List<Tag>() { new Tag() },
                    Category = new Category() { CategoryKey = (uint)(8+i), Name = "Artificial Intelligence" },
                    Votes = 149,
                    CreatedAt = DateTime.Now
                });
            }
            return posts;
        }

        public IEnumerable<Post> GetPost(int UserId, int StartPage, int NumberOfPage, int NumberOfRecordPerPage)
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
            };

            posts.Add(new Post());
            return posts;
        }

        public Post GetPost(int Id)
        {
            return new Post()
            {
                BrowserTitle = "First post TinyBlog",
                Title = "Blog Titile",
                SubTitle = "Subtitle of the page and hence",
                MainContentImageUrl = "http://localhost:4200/assets/images/blog.jpg",
                MainContentImageSubtitle = "the camera never speaks.",
                Content = @"<p>
        Lorem ipsum dolor sit amet, consectetur adipiscing elit. In tempus sem augue, feugiat hendrerit lacus rutrum in. Vivamus faucibus ullamcorper nisi vitae auctor. Donec hendrerit accumsan lectus. Nulla gravida, orci in finibus elementum, felis est convallis neque, nec hendrerit urna odio ut nulla. Fusce augue nunc, ornare in risus at, porttitor molestie lectus. Aliquam a fermentum nulla. Sed molestie tristique leo eget lobortis. Pellentesque molestie pulvinar massa laoreet tristique. Cras convallis ac ante vitae lacinia. Nunc imperdiet elementum congue. In hac habitasse platea dictumst. Suspendisse iaculis bibendum dolor vitae blandit. Phasellus ac diam placerat, tempor mi ut, luctus dolor. Nulla facilisi.
        </p>
        <p>
        Vivamus vitae nibh sodales, accumsan mauris egestas, laoreet justo. Pellentesque felis nisi, pellentesque ut pulvinar ultricies, eleifend quis arcu. Suspendisse iaculis odio non orci vulputate pretium at ac lacus. Vestibulum commodo diam eget tortor accumsan, at auctor risus tempor. Phasellus eget metus id nulla vehicula iaculis nec quis risus. Vivamus fringilla lectus turpis, eu viverra arcu sodales ut. Pellentesque et lectus nunc. Quisque efficitur quis erat ut facilisis. Nunc ut imperdiet lorem, ut cursus est. Phasellus tincidunt risus lectus, in mattis est venenatis a.
        </p>
        <p>
        Donec dui risus, finibus non lacus ac, tincidunt hendrerit ex. Nam laoreet erat sit amet laoreet hendrerit. Aliquam purus lorem, commodo ac suscipit non, vehicula vel mi. Phasellus vel tristique elit, ut venenatis urna. Phasellus sagittis sem sit amet metus tempus, a vehicula leo lacinia. Vestibulum interdum nisl in ornare consequat. Suspendisse eleifend lorem eget justo vulputate posuere. Fusce viverra lectus nec finibus blandit. Sed fermentum, nisi sit amet posuere maximus, massa risus pulvinar massa, vel suscipit nisl nulla vel neque. Suspendisse aliquet, nibh sed accumsan imperdiet, mi purus condimentum ipsum, a convallis dui nisl nec sapien.
        </p>
        <p>
        Maecenas auctor felis eget tincidunt euismod. Pellentesque interdum vulputate convallis. Proin placerat eleifend nunc sed placerat. Ut lobortis eu risus blandit mattis. Morbi rutrum facilisis varius. Nam id metus blandit, aliquam quam vitae, bibendum magna. In hac habitasse platea dictumst. Nulla vel felis efficitur, efficitur purus non, gravida orci.
        </p>
        <p>
        Vestibulum finibus dapibus aliquam. Donec aliquet nulla diam, ac tincidunt nulla euismod eu. Aenean tempus neque libero, venenatis pellentesque magna tincidunt a. In vitae euismod neque. Duis venenatis ornare nunc ut accumsan. Integer felis lorem, luctus at elit eget, semper tincidunt dolor. In vulputate non sapien vitae vehicula. Phasellus lorem justo, fermentum eget egestas a, tristique eu ex. Integer neque felis, tincidunt eget ligula vel, pulvinar vehicula orci. Aenean faucibus massa ut ex cursus tempor. Nunc felis quam, commodo sit amet felis sit amet, dignissim mollis dolor. Fusce eget est in nunc vestibulum tempus vulputate ut urna. Sed aliquam semper magna id ullamcorper. Aenean rhoncus ultricies arcu, non faucibus justo porta non. Nullam enim turpis, semper non euismod vitae, bibendum a ex. Mauris gravida velit est, eu egestas nibh aliquet ut.
        </p>",
                Author = new User()
                {
                    Name = "New Awesome user",
                    About = "Awesome user creates Awesome blogs",
                    ImageUrl = "http://localhost:4200/assets/images/user.jpg",
                    Categories = new List<Category>() { new Category() { Name = "Amazone Web Developer" } },
                    Vote = 243
                },
                Previous = "http://localhost:4200/post/320/blog%2Btitle%2Bnew%2Burl",
                Next = "http://localhost:4200/post/320/blog%2Btitle%2Bnew%2Burl",
                Votes = 345
            };
        }

        public Comment UpdateComment(uint id, string commentContent)
        {
            Comment comment = new Comment();
            comment.CommentKey = id;
            comment.Content = commentContent;
            return comment;
        }

        public bool UpdateInformation(int Id, string PostContent)
        {
            return true;
        }

        public bool UpdateTitle(int Id, string Title)
        {
            return true;
        }
    }
}
