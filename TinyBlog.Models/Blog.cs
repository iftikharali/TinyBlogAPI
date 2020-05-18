using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TinyBlog.Models
{
    public class Recommend
    {
        public User RecommendBy { get; set; }
        public User RecommendTo { get; set; }
    }
    public class Blog
    {
        public Blog()
        {
            this.MetaTag = new Dictionary<string, string>();
            this.Tags = new List<Tag>();
        }
        private string _removeHTMLTagFromText(string textWithHTMLTags)
        {
            string outPut = string.Empty;
            outPut = Regex.Replace(textWithHTMLTags, "<[^>]*>", string.Empty);

            //get rid of multiple blank lines
            outPut = Regex.Replace(outPut, @"^\s*$\n", string.Empty, RegexOptions.Multiline);

            return outPut.Trim();
        }
        public int BlogKey { get; set; }
        public Guid BlogGuid { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string MainContentImageUrl { get; set; }
        public string MainContentImageSubtitle { get; set; }
        /// <summary>
        /// contains key as tags and value as comma separated tag value
        /// </summary>
        public Dictionary<string,string> MetaTag { get; set; }
        public string BrowserTitle { get; set; }
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
        public User Owner { get; set; }
        public string Url { get {
                return "blog/" + BlogKey + "/" + Title?.Replace(" ", "-");
            }
        }
        public string SortUrl { get; set; }
        public string Content { get; set; }
        public string Excerpt { get { return Content==null?null: this._removeHTMLTagFromText(Content.Substring(0, 100)+"..."); } }
        public IEnumerable<Tag> Tags { get; set; }
        public bool IsActive { get; set; } = true;
        public List<User> Subscribers { get; set; }
        public int SubscriberCount { get; set; }
        public int Views { get; set; }
        public int Recommend { get; set; }
        public DateTime CreatedAt { get; set; }
        public User CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User UpdatedBy { get; set; }
    }
}
