using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repository.IRepository
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        IEnumerable<Tag> GetTagByUrlSlug(string urlSlug);
    }
}
