using System;
using System.Collections.Generic;
using System.Text;

namespace TinyBlog.Models
{
    public class ApplicationContext
    {
        public int UserKey {get;set;}
        public string BaseUrl { get; set; }
        public ApplicationContext(int UserKey,string BaseUrl=null)
        {
            this.UserKey = UserKey==0?1:UserKey;
            this.BaseUrl = BaseUrl;
            
        }
    }
}
