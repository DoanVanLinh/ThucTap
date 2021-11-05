using FA.JustBlog.Core.Models;
using FA.JustBlog.Models.Entities;
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

            if (context.Posts.Any() && context.Categories.Any() && context.Tags.Any() && context.PostTags.Any() && context.Comments.Any())
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
                Modified = false,
                ViewCount = 1,
                RateCount = 1,
                TotalRate = 1
            };

            var post2 = new Post()
            {
                Title = "Title 2",
                ShortDescription = "Short Description 2",
                PostContent = "Post Content 2",
                UrlSlug = "URL 2",
                Published = true,
                PostedOn = DateTime.Now,
                Modified = false,
                ViewCount = 2,
                RateCount = 2,
                TotalRate = 2
            };

            var post3 = new Post()
            {
                Title = "Title 3",
                ShortDescription = "Short Description 3",
                PostContent = "Post Content 3",
                UrlSlug = "URL 3",
                Published = true,
                PostedOn = DateTime.Now,
                Modified = false,
                ViewCount = 3,
                RateCount = 3,
                TotalRate = 3
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

            //PostTag
            var postTag = new PostTag()
            {
                PostId = post1.Id,
                TagId = tag1.Id
            };
            var postTag1 = new PostTag()
            {
                PostId = post2.Id,
                TagId = tag2.Id
            }; 
            var postTag2 = new PostTag()
            {
                PostId = post3.Id,
                TagId = tag3.Id
            };
            List<PostTag> postTags = new List<PostTag>() { postTag, postTag1, postTag2 };

            //Comment
            var comment1 = new Comment()
            {
                Name = "Comment 1",
                Email = "Email 1",
                CommentHeader = "Cmt Header 1",
                CommentText = "Cmt Text 1",
                CommentTime = DateTime.Now
            };

            var comment2 = new Comment()
            {
                Name = "Comment 2",
                Email = "Email 2",
                CommentHeader = "Cmt Header 2",
                CommentText = "Cmt Text 2",
                CommentTime = DateTime.Now
            };

            var comment3 = new Comment()
            {
                Name = "Comment 3",
                Email = "Email 3",
                CommentHeader = "Cmt Header 3",
                CommentText = "Cmt Text 3",
                CommentTime = DateTime.Now
            };
            List<Comment> comments = new List<Comment>() { comment1, comment2, comment3 };


            category1.Posts.Add(post1);
            category2.Posts.Add(post2);
            category3.Posts.Add(post3);

            post1.Comments.Add(comment1);
            post2.Comments.Add(comment1);
            post2.Comments.Add(comment2);
            post3.Comments.Add(comment1);
            post3.Comments.Add(comment2);
            post3.Comments.Add(comment3);

            postTag.Posts = post1;
            postTag.Tags = tag1;
            postTag1.Posts = post2;
            postTag1.Tags = tag2;
            postTag2.Posts = post3;
            postTag2.Tags = tag3;

            context.Categories.AddRange(categories);
            context.Posts.AddRange(posts);
            context.Comments.AddRange(comments);
            context.Tags.AddRange(tags);
            //context.PostTags.AddRange(postTags);

            context.SaveChanges();
        }

    }
}
