using FA.JustBlog.Core.Common;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("CategoryManager/{action}")]
    public class CategoryManagerController : Controller
    {
        private IUnitOfWork uow;
        public CategoryManagerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: CategoryManagerController
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            var result = uow.CategoryRepository.GetAll().OrderByDescending(p => p.CategoryId).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalRecord = uow.CategoryRepository.GetAll().Count();
            return View(result);
        }

        // GET: CategoryManagerController/Details/5
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                var post = uow.CategoryRepository.Find(id.Value);
                if (post != null)
                {
                    return View(post);
                }
            }
            return RedirectToAction("Index");
        }

        // GET: CategoryManagerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category categories)
        {
            var rs = SeoUrlHepler.ToUrlSlug(categories.Name);
            categories.UrlSlug = rs;
            uow.CategoryRepository.Add(categories);
            uow.SaveChange();
            return RedirectToAction("Index");
        }

        // GET: CategoryManagerController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = uow.CategoryRepository.Find(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: CategoryManagerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            
            var rs = SeoUrlHepler.ToUrlSlug(category.Name);
            category.UrlSlug = rs;



            uow.CategoryRepository.Update(category);
            uow.SaveChange();



            return RedirectToAction("Index");
        }

        // GET: CategoryManagerController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                uow.CategoryRepository.Delete(id.Value);
            }
            return RedirectToAction("Index");
        }

        // POST: CategoryManagerController/Delete/5
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
