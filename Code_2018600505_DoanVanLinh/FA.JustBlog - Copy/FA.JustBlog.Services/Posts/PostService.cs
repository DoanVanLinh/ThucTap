using AutoMapper;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Models.Enums;
using FA.JustBlog.Services.IPost;
using FA.JustBlog.ViewModels.Posts;
using FA.JustBlog.ViewModels.Results;
using FA.JustBlog.ViewModels.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork unitOfWork;
        public PostService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ResponseResult Create(CreatePostViewModel request)
        {
            try
            {
                var tagIds = this.unitOfWork.TagRepository.AddTagByString(request.Tag);
                var postTags = new List<PostTag>();
                foreach (var tag in tagIds)
                {
                    var postTag = new PostTag()
                    {
                        TagId = tag,
                        PostId = request.Id
                    };
                    postTags.Add(postTag);
                }

                var post = new Post()
                {
                    Title = request.Title,
                    PostTags = postTags,
                    CategoryId = request.CategoryId,
                    Modified = false,
                    PostContent = request.PostContent,
                    PostedOn = request.PostedOn,
                    Published = request.Published,
                    ShortDescription = request.ShortDescription,
                    Status = Status.Active,
                    UrlSlug = request.UrlSlug,
                    RateCount = request.RateCount,
                    TotalRate = request.TotalRate,
                    ViewCount = request.ViewCount
                };

                //var post = Mapper.Map<Post>(request);
                this.unitOfWork.PostRepository.Add(post);
                this.unitOfWork.SaveChange();
                return new ResponseResult();
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message);
            }
        }

        public ResponseResult Delete(DeletePostViewModel request)
        {
            try
            {
                var post = Mapper.Map<Post>(request);
                this.unitOfWork.PostRepository.Delete(post.Id);
                this.unitOfWork.SaveChange();
                return new ResponseResult();
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message);
            }
        }

        public ResponseResult Edit(EditPostViewModel request, string oldTag = "")
        {
            try
            {
                var tagIds = this.unitOfWork.TagRepository.AddTagByString(request.Tags, oldTag);
                var postTags = new List<PostTag>();
                foreach (var tag in tagIds)
                {
                    var postTag = new PostTag()
                    {
                        TagId = tag,
                        PostId = request.Id
                    };
                    postTags.Add(postTag);
                }

                var post = this.unitOfWork.PostRepository.GetById(request.Id);

                post.Title = request.Title;
                post.PostTags = postTags;
                post.CategoryId = request.CategoryId;
                post.Modified = false;
                post.PostContent = request.PostContent;
                post.PostedOn = request.PostedOn;
                post.Published = request.Published;
                post.ShortDescription = request.ShortDescription;
                post.UrlSlug = request.UrlSlug;
                post.Id = request.Id;
                post.RateCount = request.RateCount;
                post.TotalRate = request.TotalRate;
                post.ViewCount = request.ViewCount;

                //var post = new Post()
                //{
                //    Title = request.Title,
                //    PostTags = postTags,
                //    CategoryId = request.CategoryId,
                //    Modified = false,
                //    PostContent = request.PostContent,
                //    PostedOn = request.PostedOn,
                //    Published = request.Published,
                //    ShortDescription = request.ShortDescription,
                //    Status = Status.Active,
                //    UrlSlug = request.UrlSlug,
                //    RateCount = request.RateCount,
                //    TotalRate = request.TotalRate,
                //    ViewCount = request.ViewCount
                //};

                //this.unitOfWork.PostRepository.Delete(Mapper.Map<Post>(request));
                //this.unitOfWork.PostRepository.Add(post);

                this.unitOfWork.PostRepository.Update(post);
                this.unitOfWork.SaveChange();
                return new ResponseResult();
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message);
            }
        }

        public IEnumerable<PostViewModel> GetAll()
        {
            var posts = this.unitOfWork.PostRepository.GetAll().Where(p => p.Status != Status.IsDeleted);
            return Mapper.Map<IEnumerable<PostViewModel>>(posts);
        }

        public EditPostViewModel GetEditPostById(int id)
        {
            var post = unitOfWork.PostRepository.GetById(id);
            var tags = "";
            foreach (var postTag in post.PostTags)
            {
                var tag = this.unitOfWork.TagRepository.GetById(postTag.TagId);
                tags += tag.Name + "; ";
            }
            EditPostViewModel postEditViewModel = Mapper.Map<EditPostViewModel>(post);
            postEditViewModel.Tags = tags;
            return postEditViewModel;
        }
        public DeletePostViewModel GetDeletePostById(int id)
        {
            var post = unitOfWork.PostRepository.GetById(id);
            return Mapper.Map<DeletePostViewModel>(post);
        }
        public PostDetailViewModel GetDetailPostById(int id)
        {
            var post = unitOfWork.PostRepository.GetById(id);
            var tags = new List<TagViewModel>();
            foreach (var postTag in post.PostTags)
            {
                var tag = this.unitOfWork.TagRepository.GetById(postTag.TagId);
                tags.Add(Mapper.Map<TagViewModel>(tag));
            }
            PostDetailViewModel postDetailViewModel = Mapper.Map<PostDetailViewModel>(post);
            postDetailViewModel.Tags = tags;
            return postDetailViewModel;
        }

    }
}
