using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Comments
{
    public class CreateCommentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Email")]
        [StringLength(255)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Tiêu đề bình luận")]
        public string CommentHeader { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Bình luận")]
        [StringLength(1024)]
        public string CommentText { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Ngày bình luận")]
        public DateTime? CommentTime { get; set; }

        [Display(Name = "Tiêu đề bài viết")]
        public int? PostId { get; set; }
    }
}
