using AutoMapper;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Models.Enums;
using FA.JustBlog.ViewModels.Categories;
using FA.JustBlog.ViewModels.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FA.JustBlog.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ResponseResult Create(CreateCategoryViewModel request)
        {

            try
            {
                var category = Mapper.Map<Category>(request);
                this.unitOfWork.CategoryRepository.Add(category);
                this.unitOfWork.SaveChange();
                return new ResponseResult();
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message);
            }
        }

        public ResponseResult Delete(DeleteCategoryViewModel request)
        {
            try
            {
                var category = Mapper.Map<Category>(request);
                this.unitOfWork.CategoryRepository.Delete(category.Id);
                this.unitOfWork.SaveChange();
                return new ResponseResult();
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message);
            }
        }

        public ResponseResult Edit(EditCategoryViewModel request)
        {
            try
            {
                var category = Mapper.Map<Category>(request);
                this.unitOfWork.CategoryRepository.Update(category);
                this.unitOfWork.SaveChange();
                return new ResponseResult();
            }
            catch (Exception ex)
            {
                return new ResponseResult(ex.Message);
            }
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            var categories = this.unitOfWork.CategoryRepository.GetAll().Where(p => p.Status != Status.IsDeleted);
            return Mapper.Map<IEnumerable<CategoryViewModel>>(categories);
        }

        public EditCategoryViewModel GetEditCategoryById(int id)
        {
            var category = unitOfWork.CategoryRepository.GetById(id);
            return Mapper.Map<EditCategoryViewModel>(category);
        }
        public DeleteCategoryViewModel GetDeleteCategoryById(int id)
        {
            var category = unitOfWork.CategoryRepository.GetById(id);
            return Mapper.Map<DeleteCategoryViewModel>(category);
        }
        public CategoryDetailViewModel GetDetailCategoryById(int id)
        {
            var category = unitOfWork.CategoryRepository.GetById(id);
            return Mapper.Map<CategoryDetailViewModel>(category);
        }

    }
}
