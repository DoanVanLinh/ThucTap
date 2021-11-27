using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Models.Entities;
using FA.JustBlog.ViewModels.Categories;
using FA.JustBlog.ViewModels.Comments;
using FA.JustBlog.ViewModels.Posts;
using FA.JustBlog.ViewModels.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA.JustBlog.App_Start
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CreatePostViewModel, Post>().ReverseMap();
            CreateMap<PostViewModel, Post>().ReverseMap();
            CreateMap<EditPostViewModel, Post>().ReverseMap();
            CreateMap<DeletePostViewModel, Post>().ReverseMap();
            CreateMap<PostDetailViewModel, Post>().ReverseMap();

            CreateMap<CreateCategoryViewModel, Category>().ReverseMap();
            CreateMap<CategoryViewModel, Category>().ReverseMap();
            CreateMap<EditCategoryViewModel, Category>().ReverseMap();
            CreateMap<DeleteCategoryViewModel, Category>().ReverseMap();
            CreateMap<CategoryDetailViewModel, Category>().ReverseMap();

            CreateMap<CreateTagViewModel, Tag>().ReverseMap();
            CreateMap<TagViewModel, Tag>().ReverseMap();
            CreateMap<EditTagViewModel, Tag>().ReverseMap();
            CreateMap<DeleteTagViewModel, Tag>().ReverseMap();
            CreateMap<TagDetailViewModel, Tag>().ReverseMap();

            CreateMap<CreateCommentViewModel, Comment>().ReverseMap();
            CreateMap<CommentViewModel, Comment>().ReverseMap();
            CreateMap<EditCommentViewModel, Comment>().ReverseMap();
            CreateMap<DeleteCommentViewModel, Comment>().ReverseMap();
            CreateMap<CommentDetailViewModel, Comment>().ReverseMap();
        }
    }
}