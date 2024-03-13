using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class PageSeo : EntityBase
    {
        public PageSeo()
        {
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Page { get; set; }

        public PageSeo(string title, string description, string keywords, string page)
        {
            Title = title;
            Description = description;
            Keywords = keywords;
            Page = page;
        }
    }
}
