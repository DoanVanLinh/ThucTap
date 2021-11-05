using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Posts
{
    public class CreatePostViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Tiêu đề")]
        [StringLength(255)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Mô tả ngắn")]
        [StringLength(1024)]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Nội dung")]
        public string PostContent { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "URL")]
        [StringLength(255)]
        public string UrlSlug { get; set; }

        [Display(Name = "Công khai")]
        public bool Published { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Ngày đăng")]
        public DateTime? PostedOn { get; set; }

        [Display(Name = "Đã chỉnh sửa")]
        public bool Modified { get; set; }
        [Display(Name = "Danh mục")]
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Display(Name ="Tag(các nhau bằng dấu ;)")]
        public string Tag { get; set; }

        [Display(Name = "Số lượt xem")]
        public int ViewCount { get; set; }

        [Display(Name = "Số lượt đánh giá")]
        public int RateCount { get; set; }

        [Display(Name = "Tổng đánh giá")]
        public int TotalRate { get; set; }

    }
}
