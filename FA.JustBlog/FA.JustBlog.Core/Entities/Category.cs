using FA.JustBlog.Models.EntityBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Posts = new List<Post>();
        }

        [Required()]
        [StringLength(30)]
        public string Name { get; set; }

        [Required()]
        [StringLength(255)]
        public string UrlSlug { get; set; }

        [Required()]
        [StringLength(1024)]
        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
