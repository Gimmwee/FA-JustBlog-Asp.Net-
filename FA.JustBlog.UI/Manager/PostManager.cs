using FA.JustBlog.Core.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.UI.Manager
{
    public class PostManager
    {
        private readonly IUnitOfWork repository = new UnitOfWork();

        /// <summary>
        /// Gett All Book
        /// </summary>
        public void DisplayAllPost()
        {
            using (var uow = new UnitOfWork())
            {
                var books = uow.PostRepository.GetAll();

                books.ToList().ForEach(b => Console.WriteLine($"{b.PostId}|" +
                    $"{b.Title}\t|" +
                    $"{b.ShortDescription}\t|" +
                    $"{b.PostContent}\t|" +
                    $"{b.UrlSlug}\t|" +
                    $"{b.Published}\t|" +
                    $"{b.PostedOn.Value.ToString("dd MMMM yyyy")}\t|" +
                    $"{b.Modified.Value.ToString("dd MMMM yyyy")}\t|" +
                    $"{b.CategoryId}\t|"));
            }

        }
        public void FindPost()
        {
            using (var uow = new UnitOfWork())
            {
                var findposts = uow.PostRepository.FindPost(2023, 03, "how-to-build-a-responsive-website");

                Console.WriteLine(($"{findposts.PostId}|" +
                    $"{findposts.Title}\t|" +
                    $"{findposts.ShortDescription}\t|" +
                    $"{findposts.PostContent}\t|" +
                    $"{findposts.UrlSlug}\t|" +
                    $"{findposts.Published}\t|" +
                    $"{findposts.PostedOn.Value.ToString("dd MMMM yyyy")}\t|" +
                    $"{findposts.Modified.Value.ToString("dd MMMM yyyy")}\t|" +
                    $"{findposts.CategoryId}\t|"));
            }

        }
    }
}
