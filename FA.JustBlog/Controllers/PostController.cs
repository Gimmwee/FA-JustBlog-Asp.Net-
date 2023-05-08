using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FA.JustBlog.Controllers
{
    [Route("Post/{action}")]
    public class PostController : Controller
    {
        private IUnitOfWork uow;
        public PostController(IUnitOfWork uow)
        {
            this.uow = uow;
        }


        [Route("")]
        public IActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);

            var result = uow.PostRepository.GetAll().OrderByDescending(p => p.PostId).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalRecord = uow.PostRepository.GetAll().Count();

            return View(result);

        }

        public IActionResult Detail(int? pid)
        {
            if (pid.HasValue)
            {
                var result = uow.PostRepository.Find(pid.Value);
                if (result != null)
                {
                    return View(result);
                }
            }
            return RedirectToAction("Index");
        }


        public IActionResult DetailbyUrlSlug(string? urlSlug)
        {

            var result = uow.PostRepository.GetPostByUrlSlug(urlSlug);
            var comments = uow.CommentRepository.GetCommentsForPost(result.PostId).OrderByDescending(t => t.CommentTime).ToList();
            ViewBag.Comments = comments;
            if (result != null)
            {
                return View(result);
            }
            return RedirectToAction("Index");
        }
        public IActionResult GetPostsByTag(string? tag, int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);

            var result = uow.PostRepository.GetPostsByTag(tag).OrderByDescending(p => p.PostId).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalRecord = uow.PostRepository.GetAll().Count();

            return View(result);
        }
        [HttpPost]
        public IActionResult Comment(int postid, string email, string name, string commentText, string commentHeader)
        {
            var result = uow.PostRepository.Find(postid);

            Comment comment = new Comment
            {
                Name = name,
                Email = email,
                PostId = postid,
                CommentText = commentText,
                CommentHeader = commentHeader,
                CommentTime = DateTime.Now
            };
            if (comment != null)
            {
                uow.CommentRepository.Add(comment);
                uow.SaveChange();
                return RedirectToAction("DetailbyUrlSlug", "Post", new { urlSlug = result.UrlSlug });
            }



            return RedirectToAction("Index");
        }
        public IActionResult Category(string cname)
        {

            var result = uow.PostRepository.GetPostsByCategory(cname);
            if (result != null)
            {
                return View(result);
            }
            return RedirectToAction("Index");
        }


    }
}
