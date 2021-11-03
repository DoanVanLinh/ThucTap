using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Categories
{
    public class EditCategoryViewModel
    {

        public int Id { get; set; }
        [Required()]
        [StringLength(30)]
        [Display(Name = "Danh mục")]
        public string Name { get; set; }

        [Required()]
        [StringLength(255)]
        [Display(Name = "URL")]
        public string UrlSlug { get; set; }

        [Required()]
        [StringLength(1024)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
