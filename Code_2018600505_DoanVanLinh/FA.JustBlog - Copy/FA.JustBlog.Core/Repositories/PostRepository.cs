using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(JustBlogContext context) : base(context)
        {

        }

        public int CountPostsForCategory(string category)
        {
            return GetPostsByCategory(category).Count();
        }

        public int CountPostsForTag(string tag)
        {
            return GetPostsByTag(tag).Count();
        }

        public IList<Post> GetHighestPosts()
        {
            return Find(p => p.Id == GetAll().Max(p1 => p1.TotalRate)).ToList();
        }

        public IList<Post> GetLatestPost()
        {
            return Find(p => p.Id == GetAll().Max(p1 => p1.Id)).ToList();
        }

        public IList<Post> GetMostViewedPost()
        {
            return Find(p => p.Id == GetAll().Max(p1 => p1.ViewCount)).ToList();
        }

        public IList<Post> GetPostsByCategory(string category)
        {
            return Find(p => p.Category.Name == category).ToList();
        }

        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            return Find(p => p.PostedOn == monthYear).ToList();
        }

        public IList<Post> GetPostsByTag(string tag)
        {
            //return Find(p => p.PostTagMaps.).ToList();
            return null;
        }

        public IList<Post> GetPublisedPosts()
        {
            return Find(p => p.Published == true).ToList();
        }

        public IList<Post> GetUnpublisedPosts()
        {
            return Find(p => p.Published == false).ToList();
        }
    }
}
