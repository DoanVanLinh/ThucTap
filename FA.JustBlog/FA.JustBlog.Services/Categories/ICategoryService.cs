using FA.JustBlog.ViewModels.Categories;
using FA.JustBlog.ViewModels.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Categories
{
    public interface ICategoryService
    {
        ResponseResult Create(CreateCategoryViewModel request);
        ResponseResult Edit(EditCategoryViewModel request);
        ResponseResult Delete(DeleteCategoryViewModel request);

        IEnumerable<CategoryViewModel> GetAll();
        EditCategoryViewModel GetEditCategoryById(int id);
        DeleteCategoryViewModel GetDeleteCategoryById(int id);
        CategoryDetailViewModel GetDetailCategoryById(int id);
    }
}
