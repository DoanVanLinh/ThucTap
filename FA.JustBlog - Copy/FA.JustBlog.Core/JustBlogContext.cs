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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOptional(p => p.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Tags)
                .WithMany(t => t.Posts)
                .Map(cs =>
                {
                    cs.MapLeftKey("PostRefId");
                    cs.MapRightKey("TagRefId");
                    cs.ToTable("PostTag");
                });
        }
    }
}
