using AutoMapper;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Models.Enums;
using FA.JustBlog.Services.IPost;
using FA.JustBlog.ViewModels.Posts;
using FA.JustBlog.ViewModels.Results;
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
                var post = Mapper.Map<Post>(request);
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

        public ResponseResult Edit(EditPostViewModel request)
        {
            try
            {
                var post = Mapper.Map<Post>(request);
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
            return Mapper.Map<EditPostViewModel>(post);
        }
        public DeletePostViewModel GetDeletePostById(int id)
        {
            var post = unitOfWork.PostRepository.GetById(id);
            return Mapper.Map<DeletePostViewModel>(post);
        }
        public PostDetailViewModel GetDetailPostById(int id)
        {
            var post = unitOfWork.PostRepository.GetById(id);
            return Mapper.Map<PostDetailViewModel>(post);
        }

    }
}
