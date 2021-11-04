using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        Tag GetTagByUrlSlug(string urlSlug);
        IEnumerable<int> AddTagByString(string tag,string oldTag = "");

    }
}
