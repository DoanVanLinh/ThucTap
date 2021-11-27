using FA.JustBlog.Common;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories
{
    public class TagReponsitory : GenericRepository<Tag>, ITagRepository
    {
        public TagReponsitory(JustBlogContext context) : base(context)
        {
            Console.WriteLine("TagReponsitory  is created");
        }

        public IEnumerable<int> AddTagByString(string newTag, string oldTag = "")
        {
            var newTagName = newTag.Split(';');
            if (oldTag.Equals(""))
                oldTag = newTag;
            var oldTagName = oldTag.Split(';');

            

            //for edit
            foreach (var oldTagItem in oldTagName)
            {
                if (!newTagName.ToList().Contains(oldTagItem))
                {
                    var tagExisting = this.dbSet.Where(t => t.Name.Trim().ToLower() == oldTagItem.Trim().ToLower());
                    if (tagExisting.Count() != 0)
                    {
                        this.dbSet.RemoveRange(tagExisting);//remove tag not use
                    }
                }
            }

            foreach (var item in newTagName)
            {
                if (!item.Trim().Equals(""))
                {
                    var tagExisting = this.dbSet.Where(t => t.Name.Trim().ToLower() == item.Trim().ToLower()).Count();
                    if (tagExisting == 0)
                    {
                        var tagg = new Tag()
                        {
                            Name = item,
                            UrlSlug = UrlHepler.FrientlyUrl(item),
                            Count = 1,
                            Description = "Description",
                            Status = Status.Active,
                            PostTags = null,
                        };
                        this.dbSet.Add(tagg);
                    }
                }
            }
            this.context.SaveChanges();

            foreach (var item in newTagName)
            {
                var tagExisting = this.dbSet.FirstOrDefault(t => t.Name.Trim().ToLower() == item.Trim().ToLower());
                if (tagExisting != null)
                {
                    yield return tagExisting.Id;//return lan luot id, cho den khi ket thuc vong for => return toan bo
                }
            }
        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return Find(t => t.UrlSlug == urlSlug).FirstOrDefault();
        }

    }
}
