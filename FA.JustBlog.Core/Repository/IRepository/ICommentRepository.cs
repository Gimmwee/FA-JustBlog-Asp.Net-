using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repository.IRepository
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {

        void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody);
        IList<Comment> GetCommentsForPost(int postId);
        IList<Comment> GetCommentsForPost(Post post);
    }
}
