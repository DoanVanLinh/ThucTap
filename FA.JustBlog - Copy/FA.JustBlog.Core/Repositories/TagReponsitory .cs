using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories
{
    public class TagReponsitory : GenericRepository<Tag>, ITagRepository
    {
        public TagReponsitory(JustBlogContext context) : base(context)
        {
            Console.WriteLine("TagReponsitory  is created");
        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return Find(t => t.UrlSlug == urlSlug).FirstOrDefault();
        }
    }
}
