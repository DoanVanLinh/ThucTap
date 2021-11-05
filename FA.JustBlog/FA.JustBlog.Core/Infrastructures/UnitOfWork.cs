using FA.JustBlog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JustBlogContext context;
        private ICategoryRepository categoryRepository;
        private IPostRepository postRepository;
        private ITagRepository tagRepository;
        private ICommentRepository commentRepository;

        public UnitOfWork(JustBlogContext context)
        {
            this.context = context;
        }
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new CategoryRepository(this.context);
                }
                return this.categoryRepository;

            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                if (this.commentRepository == null)
                {
                    this.commentRepository = new CommentRepository(this.context);
                }
                return this.commentRepository;

            }
        }
        public IPostRepository PostRepository
        {
            get
            {
                if (this.postRepository == null)
                {
                    this.postRepository = new PostRepository(this.context);
                }
                return this.postRepository;

            }
        }
        public ITagRepository TagRepository
        {
            get
            {
                if (this.tagRepository == null)
                {
                    this.tagRepository = new TagReponsitory(this.context);
                }
                return this.tagRepository;

            }
        }


        public JustBlogContext JustBlogContext => throw new NotImplementedException();

        public void Dispose()
        {
            this.context.Dispose();
        }

        public int SaveChange()
        {
            return this.context.SaveChanges();
        }

        public async Task<int> SaveChangeAsync()
        {
            return await this.context.SaveChangesAsync();
        }
    }
}
