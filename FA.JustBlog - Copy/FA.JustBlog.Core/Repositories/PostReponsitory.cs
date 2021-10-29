using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories
{
    public class PostReponsitory : GenericRepository<Post>, IPostRepository
    {
        public PostReponsitory(JustBlogContext context) : base(context)
        {
            Console.WriteLine("PostReponsitory is created");
        }

        public int CountPostsForCategory(string category)
        {
            return GetPostsByCategory(category).Count();
        }

        public int CountPostsForTag(string tag)
        {
            return GetPostsByTag(tag).Count();
        }

        public IList<Post> GetLatestPost(int size)
        {
            return Find(p=>p.Id == GetAll().Max(p1=>p1.Id)).ToList();
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
            return Find(p => p.Tags.Any(t => t.Name == tag)).ToList();
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
