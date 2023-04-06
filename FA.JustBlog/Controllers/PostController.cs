using FA.JustBlog.Core.DataContext;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index()
        {

            var result = uow.PostRepository.GetAll();

            return View(result.ToList());

        }

        public IActionResult Detail(int? pid)
        {
            if (pid.HasValue)
            {
                var result = uow.PostRepository.GetPostById(pid.Value);
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
            if (result != null)
            {
                return View(result);
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
