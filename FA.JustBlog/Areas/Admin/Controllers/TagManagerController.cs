using FA.JustBlog.Core.Common;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FA.JustBlog.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Route("TagManager/{action}")]
    public class TagManagerController : Controller
	{
        private IUnitOfWork uow;
        public TagManagerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: TagManagerController
        public ActionResult Index(int? page)
        {

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var result = uow.TagRepository.GetAll().OrderByDescending(p => p.TagId).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalRecord = uow.TagRepository.GetAll().Count();
            return View(result);
        }

		// GET: TagManagerController/Details/5
		public ActionResult Details(int? id)
		{
            if (id.HasValue)
            {
                var tag = uow.TagRepository.Find(id.Value);
                if (tag != null)
                {
                    return View(tag);
                }
            }
            return RedirectToAction("Index");
        }

		// GET: TagManagerController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: TagManagerController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Tag tags)
		{
            var rs = SeoUrlHepler.ToUrlSlug(tags.Name);
            tags.UrlSlug = rs;
            uow.TagRepository.Add(tags);
            uow.SaveChange();
            return RedirectToAction("Index");
        }

		// GET: TagManagerController/Edit/5
		public ActionResult Edit(int? id)
		{
            if (id == null)
            {
                return NotFound();
            }

            var tag = uow.TagRepository.Find(id.Value);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

		// POST: TagManagerController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, Tag tag)
		{

            var rs = SeoUrlHepler.ToUrlSlug(tag.Name);
            tag.UrlSlug = rs;
            uow.TagRepository.Update(tag);
            uow.SaveChange();
            return RedirectToAction("Index");
        }

		// GET: TagManagerController/Delete/5
		public ActionResult Delete(int? id)
		{
            if (id.HasValue)
            {
                uow.TagRepository.Delete(id.Value);
            }
            return RedirectToAction("Index");
        }

		// POST: TagManagerController/Delete/5
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
