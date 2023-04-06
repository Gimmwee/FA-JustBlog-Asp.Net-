using FA.JustBlog.Core.DataContext;
using FA.JustBlog.Core.Repository.ImplementRepo;
using FA.JustBlog.Core.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.UnitTests
{
    public class BaseTest
    {
        protected ICategoryRepository categoryRepository;
        protected IPostRepository postRepository;
        protected IPostTagMapRepository postTagMapRepository;
        protected ITagRepository tagRepository;
        protected JustBlogContext _context;

        public BaseTest()
        {
            DbContextOptions<JustBlogContext> dbContextOptions = new DbContextOptionsBuilder<JustBlogContext>()
                .UseInMemoryDatabase(databaseName: "JustBlogDb2").Options;

            _context = new JustBlogContext(dbContextOptions);
            _context.Seed();

            categoryRepository = new CategoryRepository(_context);
            postRepository = new PostRepository(_context);
            postTagMapRepository = new PostTagMapRepository(_context);
            tagRepository = new TagRepository(_context);
        }

    }
}
