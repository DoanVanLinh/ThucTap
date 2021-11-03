using FA.JustBlog.Core.Models;
using FA.JustBlog.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Posts
{
    public class PostDetailViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Tiê đề")]
        public string Title { get; set; }
        [Display(Name = "Mô tả ngắn")]
        public string ShortDescription { get; set; }
        [Display(Name = "Nội dung")]
        public string PostContent { get; set; }
        [Display(Name = "URL")]
        public string UrlSlug { get; set; }
        [Display(Name = "Công khai")]
        public bool Published { get; set; }
        [Display(Name = "Ngày đăng")]
        public DateTime? PostedOn { get; set; }
        [Display(Name = "Đã chỉnh sửa")]
        public bool Modified { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
        [Display(Name = "Trạng thái")]
        public Status Status { get; set; }
    }
}
