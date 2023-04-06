using FA.JustBlog.Core.DataContext;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository.GenericRepo;
using FA.JustBlog.Core.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repository.ImplementRepo
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(JustBlogContext context) : base(context)
        {

        }
        /// <summary>
        /// get tag by urlslug
        /// </summary>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        public IEnumerable<Tag> GetTagByUrlSlug(string urlSlug)
        {
            return _context.Tags.Where(t => t.UrlSlug == urlSlug);
        }
    }
}
