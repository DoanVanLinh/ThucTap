using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Comments
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Tiêu đề bình luận")]
        public string CommentHeader { get; set; }

        [Display(Name = "Ngày bình luận")]
        public DateTime? CommentTime { get; set; }
        [Display(Name = "Tiêu đề bài viết")]
        public virtual Post Post { get; set; }
    }
}
