using FA.JustBlog.Core.Common;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Route("TagManager/{action}")]
    public class TagManagerController : Controller
	{
		private readonly IUnitOfWork _uow;
		public TagManagerController(IUnitOfWork uow)
		{
			_uow = uow;

        }
		// GET: TagManagerController
		public ActionResult Index()
		{
			var rs = _uow.TagRepository.GetAll();
			return View(rs.ToList());
		}

		// GET: TagManagerController/Details/5
		public ActionResult Details(int? id)
		{
            if (id.HasValue)
            {
                var tag = _uow.TagRepository.Find(id.Value);
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
            _uow.TagRepository.Add(tags);
            _uow.SaveChange();
            return RedirectToAction("Index");
        }

		// GET: TagManagerController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: TagManagerController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
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

		// GET: TagManagerController/Delete/5
		public ActionResult Delete(int? id)
		{
            if (id.HasValue)
            {
                _uow.TagRepository.Delete(id.Value);
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
