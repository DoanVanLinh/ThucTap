using FA.JustBlog.ViewModels.Posts;
using FA.JustBlog.ViewModels.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.IPost
{
    public interface IPostService
    {
        ResponseResult Create(CreatePostViewModel request);
        ResponseResult Edit(EditPostViewModel request,string oldTag="");
        ResponseResult Delete(DeletePostViewModel request);

        IEnumerable<PostViewModel> GetAll();
        EditPostViewModel GetEditPostById(int id);
        DeletePostViewModel GetDeletePostById(int id);
        PostDetailViewModel GetDetailPostById(int id);
    }
}
