using FA.JustBlog.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Models.EntityBase
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        Status Status { get; set; }
    }
}
