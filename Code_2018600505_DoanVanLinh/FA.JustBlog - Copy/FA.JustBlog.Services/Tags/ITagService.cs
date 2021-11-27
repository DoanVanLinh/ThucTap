using FA.JustBlog.ViewModels.Tags;
using FA.JustBlog.ViewModels.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Tags
{
    public interface ITagService
    {
        ResponseResult Create(CreateTagViewModel request);
        ResponseResult Edit(EditTagViewModel request);
        ResponseResult Delete(DeleteTagViewModel request);

        IEnumerable<TagViewModel> GetAll();
        EditTagViewModel GetEditTagById(int id);
        DeleteTagViewModel GetDeleteTagById(int id);
        TagDetailViewModel GetDetailTagById(int id);
    }
}
