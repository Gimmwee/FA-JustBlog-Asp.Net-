using FA.JustBlog.Core.Common;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("CommentManager/{action}")]
    public class CommentManagerController : Controller
    {
        private IUnitOfWork uow;
        public CommentManagerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: CommentManagerController
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var result = uow.CommentRepository.GetAll().OrderByDescending(p => p.CommentId).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalRecord = uow.CommentRepository.GetAll().Count();
            return View(result);
        }

        // GET: CommentManagerController/Details/5
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                var comments = uow.CommentRepository.Find(id.Value);
                if (comments != null)
                {
                    return View(comments);
                }
            }
            return RedirectToAction("Index");
        }

        // GET: CommentManagerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommentManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comment comments)
        {
            ViewBag.PostId = uow.PostRepository.GetAll().Select(p => new SelectListItem
            {
                Text = p.Title,
                Value = p.PostId.ToString()
            });

            var rs = DateTime.Now;
            comments.CommentTime = rs;
            uow.CommentRepository.Add(comments);
            uow.SaveChange();
            return RedirectToAction("Index");
        }

        // GET: CommentManagerController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var comment = uow.CommentRepository.Find(id.Value);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        // POST: CommentManagerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Comment comment)
        {
            comment.CommentTime = DateTime.Now;

            uow.CommentRepository.Update(comment);
            uow.SaveChange();
            return RedirectToAction("Index");
        }

        // GET: CommentManagerController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                uow.CommentRepository.Delete(id.Value);
            }
            return RedirectToAction("Index");
        }

        //POST: CommentManagerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
