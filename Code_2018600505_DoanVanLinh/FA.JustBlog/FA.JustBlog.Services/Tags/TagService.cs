using AutoMapper;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Models.Enums;
using FA.JustBlog.ViewModels.Results;
using FA.JustBlog.ViewModels.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Tags
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork unitOfWork;
        public TagService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ResponseResult Create(CreateTagViewModel request)
        {

            try
            {
                var tag = Mapper.Map<Tag>(request);
                this.unitOfWork.TagRepository.Add(tag);
                this.unitOfWork.SaveChange();
                return new ResponseResult();
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message);
            }
        }

        public ResponseResult Delete(DeleteTagViewModel request)
        {
            try
            {
                var tag = Mapper.Map<Tag>(request);
                this.unitOfWork.TagRepository.Delete(tag.Id);
                this.unitOfWork.SaveChange();
                return new ResponseResult();
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message);
            }
        }

        public ResponseResult Edit(EditTagViewModel request)
        {
            try
            {
                var tag = Mapper.Map<Tag>(request);
                this.unitOfWork.TagRepository.Update(tag);
                this.unitOfWork.SaveChange();
                return new ResponseResult();
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message);
            }
        }

        public IEnumerable<TagViewModel> GetAll()
        {
            var tags = this.unitOfWork.TagRepository.GetAll().Where(p => p.Status != Status.IsDeleted);
            return Mapper.Map<IEnumerable<TagViewModel>>(tags);
        }

        public EditTagViewModel GetEditTagById(int id)
        {
            var tag = unitOfWork.TagRepository.GetById(id);
            return Mapper.Map<EditTagViewModel>(tag);
        }
        public DeleteTagViewModel GetDeleteTagById(int id)
        {
            var tag = unitOfWork.TagRepository.GetById(id);
            return Mapper.Map<DeleteTagViewModel>(tag);
        }
        public TagDetailViewModel GetDetailTagById(int id)
        {
            var tag = unitOfWork.TagRepository.GetById(id);
            return Mapper.Map<TagDetailViewModel>(tag);
        }
    }
}
