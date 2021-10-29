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
            this.Tags = new HashSet<Tag>();
        }

        [Required()]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(1024)]
        public string ShortDescription { get; set; }
        public string PostContent { get; set; }

        [Required()]
        [StringLength(255)]
        public string UrlSlug { get; set; }

        public bool Published { get; set; }

        public DateTime? PostedOn { get; set; }

        public bool Modified { get; set; }

        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
