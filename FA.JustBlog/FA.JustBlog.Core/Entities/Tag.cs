using FA.JustBlog.Models.EntityBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class Tag : BaseEntity
    {
        public Tag()
        {
            this.Posts = new HashSet<Post>();
        }

        [Key]
        public int Id { get; set; }

        [Required()]
        [StringLength(30)]
        public string Name { get; set; }

        [Required()]
        [StringLength(255)]
        public string UrlSlug { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
