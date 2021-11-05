using FA.JustBlog.ViewModels.Comments;
using FA.JustBlog.ViewModels.Posts;
using FA.JustBlog.ViewModels.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Comments
{
    public interface ICommentService
    {
        ResponseResult Create(CreateCommentViewModel request);
        ResponseResult Edit(EditCommentViewModel request,string oldTag="");
        ResponseResult Delete(DeleteCommentViewModel request);

        IEnumerable<CommentViewModel> GetAll();
        EditCommentViewModel GetEditCommentById(int id);
        DeleteCommentViewModel GetDeleteCommentById(int id);
        CommentDetailViewModel GetDetailCommentById(int id);
    }
}
