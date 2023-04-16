using FA.JustBlog.Core.Common;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository.ImplementRepo;
using FA.JustBlog.Core.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("PostManager/{action}")]
    public class PostManagerController : Controller
    {
        private IUnitOfWork uow;
        public PostManagerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: PostManagerController
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var result = uow.PostRepository.GetAll().OrderByDescending(p => p.PostId).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalRecord = uow.PostRepository.GetAll().Count();
            return View(result);

        }



        // GET: PostManagerController/Details/5
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                var post = uow.PostRepository.Find(id.Value);
                if (post != null)
                {
                    return View(post);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult getLastedPost()
        {
            var rs = uow.PostRepository.GetLatestPost(5);
            return View(rs.ToList());
        }
        public ActionResult mostViewPost()
        {
            var rs = uow.PostRepository.GetMostViewedPost(5);
            return View(rs.ToList());
        }
        public ActionResult getPostByPublished()
        {
            var rs = uow.PostRepository.GetPublisedPosts();
            return View(rs.ToList());
        }

        public ActionResult getUnPublished()
        {
            var rs = uow.PostRepository.GetUnpublisedPosts();
            return View(rs.ToList());
        }


        // GET: PostManagerController/Create
        public ActionResult Create()
        {
            //var rs = SeoUrlHepler.ToUrlSlug(post.Title);
            //post.UrlSlug = rs;
            //uow.PostRepository.Add(post);
            //return RedirectToAction("Index");
            return View();
        }

        // POST: PostManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            post.Modified = DateTime.Now;
            post.PostedOn = DateTime.Today;

            var rs = SeoUrlHepler.ToUrlSlug(post.Title);
            post.UrlSlug = rs;
            uow.PostRepository.Add(post);
            uow.SaveChange();
            return RedirectToAction("Index");
        }

        //GET: PostManagerController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = uow.PostRepository.Find(id.Value);
            if (post == null)
            {
                return NotFound(); 
            }

            return View(post);

        }

        // POST: PostManagerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post)
        {
            post.PostedOn = DateTime.Now;
            post.Modified = DateTime.Now;
            var rs = SeoUrlHepler.ToUrlSlug(post.Title);
            post.UrlSlug = rs;

            uow.PostRepository.Update(post);
            uow.SaveChange();

            return RedirectToAction("Index");
        }

        // GET: PostManagerController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                uow.PostRepository.Delete(id.Value);
            }
            return RedirectToAction("Index");
        }

    }
}
