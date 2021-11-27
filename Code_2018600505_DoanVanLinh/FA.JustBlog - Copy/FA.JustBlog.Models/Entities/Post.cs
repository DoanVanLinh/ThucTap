using FA.JustBlog.Models.Entities;
using FA.JustBlog.Models.EntityBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class Post :BaseEntity
    {
        public Post()
        {
            this.PostTags = new HashSet<PostTag>();
            this.Comments = new List<Comment>();
        }

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Tiêu đề bài viết")]
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

        [Display(Name ="Số lượt xem")]
        public int ViewCount { get; set; }

        [Display(Name = "Số lượt đánh giá")]
        public int RateCount { get; set; }

        [Display(Name = "Tổng đánh giá")]
        public int TotalRate { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
