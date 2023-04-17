using FA.JustBlog.Core.Common;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using System.Data;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("CommentManager/{action}")]
    [Authorize(Roles = ("Blog Owner,Contributor"))]
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
        [Authorize(Roles = ("Blog Owner,Contributor"))]
        // GET: CommentManagerController/Create
        public ActionResult Create()
        {
            var post = uow.PostRepository.GetAll();
            var list = new List<SelectListItem>();
            foreach (var p in post)
            {
                list.Add(new SelectListItem() { Value = p.PostId.ToString(), Text = p.Title });
            }
            ViewData["posts"] = list;
            return View();
        }
        [Authorize(Roles = ("Blog Owner,Contributor"))]
        // POST: CommentManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comment comments)
        {


            var rs = DateTime.Now;
            comments.CommentTime = rs;
            uow.CommentRepository.Add(comments);
            uow.SaveChange();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = ("Blog Owner,Contributor"))]

        // GET: CommentManagerController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = uow.PostRepository.GetAll();
            var list = new List<SelectListItem>();
            foreach (var p in post)
            {
                list.Add(new SelectListItem() { Value = p.PostId.ToString(), Text = p.Title });
            }
            ViewData["posts"] = list;

            var comment = uow.CommentRepository.Find(id.Value);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }
        [Authorize(Roles = ("Blog Owner,Contributor"))]
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
        [Authorize(Roles = ("Blog Owner"))]
        // GET: CommentManagerController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                uow.CommentRepository.Delete(id.Value);
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles = ("Blog Owner"))]
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
