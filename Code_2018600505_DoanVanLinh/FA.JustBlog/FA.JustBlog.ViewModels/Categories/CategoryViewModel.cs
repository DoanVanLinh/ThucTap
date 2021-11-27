using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Categories
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }
        [Display(Name = "URL")]
        public string UrlSlug { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
    }
}
