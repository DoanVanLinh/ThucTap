using FA.JustBlog.Core.Models;
using System;

using System.Data.Entity;

namespace FA.JustBlog.Core
{
    public class JustBlogContext : DbContext
    {
        public JustBlogContext() : base("name=JustBlogDbContext")
        {
            Database.SetInitializer(new JustBlogInitializer());
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
