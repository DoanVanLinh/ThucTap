using FA.JustBlog.Core.Models;
using FA.JustBlog.Models.EntityBase;
using FA.JustBlog.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Infrastructures
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity
    {
        protected readonly JustBlogContext context;
        private DbSet<T> dbSet;

        protected GenericRepository(JustBlogContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            this.dbSet.Add(entity);
        }

        public void Delete(T entity, bool isHardDelete = false)
        {
            if (!isHardDelete)
            {
                this.context.Entry<T>(entity).State = EntityState.Modified;
                entity.Status = Status.IsDeleted;
                return;

            }
            this.dbSet.Remove(entity);
        }

        public void Delete(int key, bool isHardDelete = false)
        {
            Delete(GetById(key), isHardDelete);
        }

        public IEnumerable<T> Find(Func<T, bool> condition)
        {
            return this.dbSet.Where(condition);
        }

        public IEnumerable<T> GetAll()
        {
            return this.dbSet.ToList();
        }

        public T GetById(params int[] keys)
        {
            return this.dbSet.Find(keys);
        }

        public void Update(T entity)
        {
            var exitEntity = entity;
            context.Entry(exitEntity).State = EntityState.Modified;
        }
    }
}
