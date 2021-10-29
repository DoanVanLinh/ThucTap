using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories
{
    public class CategoryReponsitory : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryReponsitory(JustBlogContext context) : base(context)
        {
            Console.WriteLine("CategoryReponsitory is created");
        }
    }
}
