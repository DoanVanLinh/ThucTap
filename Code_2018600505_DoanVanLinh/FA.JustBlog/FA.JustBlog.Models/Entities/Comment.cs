using FA.JustBlog.Core.Models;
using FA.JustBlog.Models.EntityBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Models.Entities
{
    public class Comment : BaseEntity
    {
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

        [Display(Name = "Bài viết")]
        public int? PostId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
    }
}
