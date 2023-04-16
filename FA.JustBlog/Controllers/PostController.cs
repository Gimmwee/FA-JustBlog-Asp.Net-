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
        public IActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var result = uow.PostRepository.GetAll().OrderByDescending(p => p.PostId).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalRecord = uow.PostRepository.GetAll().Count();

            return View(result);

        }

        //public IActionResult Detail(int? pid)
        //{
        //    if (pid.HasValue)
        //    {
        //        var result = uow.PostRepository.Find(pid.Value);
        //        if (result != null)
        //        {
        //            return View(result);
        //        }
        //    }
        //    return RedirectToAction("Index");
        //}


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
