using AutoMapper;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Models.Entities;
using FA.JustBlog.Models.Enums;
using FA.JustBlog.Services.IPost;
using FA.JustBlog.ViewModels.Comments;
using FA.JustBlog.ViewModels.Posts;
using FA.JustBlog.ViewModels.Results;
using FA.JustBlog.ViewModels.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork unitOfWork;
        public CommentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ResponseResult Create(CreateCommentViewModel request)
        {
            try
            {
                var comment = Mapper.Map<Comment>(request);
                this.unitOfWork.CommentRepository.Add(comment);
                this.unitOfWork.SaveChange();
                return new ResponseResult();
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message);
            }
        }

        public ResponseResult Delete(DeleteCommentViewModel request)
        {
            try
            {
                var comment = Mapper.Map<Comment>(request);
                this.unitOfWork.CommentRepository.Delete(comment.Id);
                this.unitOfWork.SaveChange();
                return new ResponseResult();
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message);
            }
        }

        public ResponseResult Edit(EditCommentViewModel request, string oldTag = "")
        {
            try
            {
                var comment = Mapper.Map<Comment>(request);
                this.unitOfWork.CommentRepository.Update(comment);
                this.unitOfWork.SaveChange();
                return new ResponseResult();
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message);
            }
        }

        public IEnumerable<CommentViewModel> GetAll()
        {
            var categories = this.unitOfWork.CommentRepository.GetAll().Where(p => p.Status != Status.IsDeleted);
            return Mapper.Map<IEnumerable<CommentViewModel>>(categories);
        }

        public DeleteCommentViewModel GetDeleteCommentById(int id)
        {
            var comment = unitOfWork.CommentRepository.GetById(id);
            return Mapper.Map<DeleteCommentViewModel>(comment);
        }

        public CommentDetailViewModel GetDetailCommentById(int id)
        {
            var comment = unitOfWork.CommentRepository.GetById(id);
            return Mapper.Map<CommentDetailViewModel>(comment);
        }

        public EditCommentViewModel GetEditCommentById(int id)
        {
            var comment = unitOfWork.CommentRepository.GetById(id);
            return Mapper.Map<EditCommentViewModel>(comment);
        }
    }
}
