using FA.JustBlog.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Models.EntityBase
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Trạng thái")]
        public Status Status { get; set; }
    }
}
