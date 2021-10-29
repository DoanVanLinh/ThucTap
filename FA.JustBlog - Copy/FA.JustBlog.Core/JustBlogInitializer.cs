using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public class JustBlogInitializer: CreateDatabaseIfNotExists<JustBlogContext>
    {
        public void SeedData(JustBlogContext context)
        {
            base.Seed(context);

            if (context.Posts.Any() && context.Categories.Any() && context.Tags.Any())
                return;
            //Category
            
            var category1 = new Category()
            {
                Name = "Category 1",
                UrlSlug = "Url 1",
                Description = "Description 1",
                Posts = new List<Post>()
            };
            var category2 = new Category()
            {
                Name = "Category 2",
                UrlSlug = "Url 2",
                Description = "Description 2",
                Posts = new List<Post>()
            };
            var category3 = new Category()
            {
                Name = "Category 3",
                UrlSlug = "Url 3",
                Description = "Description 3",
                Posts = new List<Post>()
            };
            List<Category> categories = new List<Category>() { category1, category2, category3 };

            //Post
            var post1 = new Post()
            {
                Title = "Title 1",
                ShortDescription = "Short Description 1",
                PostContent = "Post Content 1",
                UrlSlug = "URL 1",
                Published = true,
                PostedOn = DateTime.Now,
                Modified = false
            };

            var post2 = new Post()
            {
                Title = "Title 2",
                ShortDescription = "Short Description 2",
                PostContent = "Post Content 2",
                UrlSlug = "URL 2",
                Published = true,
                PostedOn = DateTime.Now,
                Modified = false
            };

            var post3 = new Post()
            {
                Title = "Title 3",
                ShortDescription = "Short Description 3",
                PostContent = "Post Content 3",
                UrlSlug = "URL 3",
                Published = true,
                PostedOn = DateTime.Now,
                Modified = false
            };
            List<Post> posts = new List<Post>() { post1, post2, post3 };

            //Tag
            var tag1 = new Tag()
            {
                Name = "Tag 1",
                UrlSlug = "URL 1",
                Description = "Description 1",
                Count = 1
            };

            var tag2 = new Tag()
            {
                Name = "Tag 2",
                UrlSlug = "URL 2",
                Description = "Description 2",
                Count = 2
            };

            var tag3 = new Tag()
            {
                Name = "Tag 3",
                UrlSlug = "URL 3",
                Description = "Description 3",
                Count = 3
            };
            List<Tag> tags = new List<Tag>() { tag1, tag2, tag3 };

            category1.Posts.Add(post1);
            category2.Posts.Add(post2);
            category3.Posts.Add(post3);

            post1.Tags.Add(tag1);
            post1.Tags.Add(tag2);
            post2.Tags.Add(tag2);
            post2.Tags.Add(tag3);
            post3.Tags.Add(tag3);
            post3.Tags.Add(tag1);

            tag1.Posts.Add(post1);
            tag1.Posts.Add(post2);
            tag2.Posts.Add(post2);
            tag2.Posts.Add(post3);
            tag3.Posts.Add(post3);
            tag3.Posts.Add(post1);

            context.Categories.AddRange(categories);
            context.Posts.AddRange(posts);
            context.Tags.AddRange(tags);

            context.SaveChanges();
        }

    }
}
