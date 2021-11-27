using FA.JustBlog.Core.Models;
using FA.JustBlog.Models.Enums;
using FA.JustBlog.ViewModels.Tags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.ViewModels.Comments
{
    public class CommentDetailViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Tiêu đề bình luận")]
        public string CommentHeader { get; set; }

        [Display(Name = "Bình luận")]
        public string CommentText { get; set; }

        [Display(Name = "Ngày bình luận")]
        public DateTime? CommentTime { get; set; }

        [Display(Name = "Tiêu đề bài viết")]
        public int? PostId { get; set; }
        public virtual Post Post { get; set; }

        [Display(Name = "Trạng thái")]
        public Status Status { get; set; }
    }
}
