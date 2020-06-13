using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TinyBlog.Models
{
    public class Post
    {
        public int PostKey { get; set; }
        public Guid PostGuid { get; set; }
        public string Title { get; set; }
        /// <summary>
        /// contains key as tags and value as comma separated tag value
        /// </summary>
        public string SubTitle { get; set; }
        public Dictionary<string, string> MetaTag { get; set; }
        public string BrowserTitle { get; set; }
        public User Author { get; set; }

        private string _removeHTMLTagFromText(string textWithHTMLTags)
        {
            if (textWithHTMLTags == "" || textWithHTMLTags == null) return "";
            string outPut = string.Empty;
            outPut = Regex.Replace(textWithHTMLTags, "<[^>]*>", string.Empty);

            //get rid of multiple blank lines
            outPut = Regex.Replace(outPut, @"^\s*$\n", string.Empty, RegexOptions.Multiline);

            return outPut.Trim();
        }
        public string Url { get
            {
                return "post/" + PostKey + "/" + this._removeHTMLTagFromText(Title)?.Replace(" ", "-");
            }
        }
        public string SortUrl { get; set; }
        public string MainContentImageUrl { get; set; }
        public string MainContentImageSubtitle { get; set; }
        public string Excerpt { get; set; }
        public string Content { get; set; }
        public bool IsPublished { get; set; } = false;
        public bool IsActive { get; set; } = true;
        /// <summary>
        /// This will hold the category
        /// </summary>
        public Category Category { get; set; }
        public int CategoryKey
        {
            get
            {
                if (Category != null)
                {
                    return Category.CategoryKey;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (Category == null)
                {
                    Category = new Category()
                    {
                        CategoryKey = value
                    };
                }
            }
        }
        public Blog Blog { get; set; }
        public int BlogKey { get
            {
                if (Blog != null)
                {
                    return Blog.BlogKey;
                }
                else
                {
                    return 0;
                }
            } set
            {
                if (Blog == null)
                {
                    Blog = new Blog()
                    {
                        BlogKey = value
                    };
                }
            }
        }
        /// <summary>
        /// Views cannot be negative so type is int.
        /// </summary>
        public int Views { get; set; }
        /// <summary>
        /// Votes can be go in negative so type is int.
        /// </summary>
        public int Votes { get; set; }
        public List<Tag> Tags { get; set; }
        public string Previous { get; set; }
        public string Next { get; set; }
        public DateTime CreatedAt { get; set; }
        public User CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User UpdatedBy { get; set; }
    }
}
