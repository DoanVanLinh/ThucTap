using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Tags
{
    public class EditTagViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(30)]
        [Display(Name = "Tên thẻ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(255)]
        [Display(Name = "URL")]
        public string UrlSlug { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0!")]
        [Display(Name = "Số lượng")]
        public int Count { get; set; }
    }
}
