using FA.JustBlog.Core.DataContext;
using FA.JustBlog.Core.Repository.ImplementRepo;
using FA.JustBlog.Core.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly JustBlogContext _context;
        private IPostRepository postRepository;
        private ICategoryRepository categoryRepository;
        private ITagRepository tagRepository;
        private IPostTagMapRepository postTagMapRepository;
        private ICommentRepository commentRepository;

        public UnitOfWork(JustBlogContext context = null)
        {
            this._context = context ?? new JustBlogContext();
        }


        public ICategoryRepository CategoryRepository => categoryRepository ?? new CategoryRepository(_context);

        public IPostRepository PostRepository => postRepository ?? new PostRepository(_context);

        public ITagRepository TagRepository => tagRepository ?? new TagRepository(_context);

        public IPostTagMapRepository PostTagMapRepository => postTagMapRepository ?? new PostTagMapRepository(_context);

        public ICommentRepository CommentRepository => commentRepository ?? new CommentRepository(_context);

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
