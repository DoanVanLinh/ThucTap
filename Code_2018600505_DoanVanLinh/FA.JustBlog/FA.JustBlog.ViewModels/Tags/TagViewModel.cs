using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Tags
{
    public class TagViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Tên thẻ")]
        public string Name { get; set; }

        [Display(Name = "URL")]
        public string UrlSlug { get; set; }
        
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        
        [Display(Name = "Số lượng")]
        public int Count { get; set; }
    }
}
