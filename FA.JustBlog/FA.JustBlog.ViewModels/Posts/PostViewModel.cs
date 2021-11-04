using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Posts
{
    public class PostViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Mô tả ngắn")]
        public string ShortDescription { get; set; }
        [Display(Name = "Công khai")]
        public bool Published { get; set; }
        [Display(Name = "Ngày đăng")]
        public DateTime? PostedOn { get; set; }
    }
}
