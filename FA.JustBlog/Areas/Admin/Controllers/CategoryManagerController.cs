﻿using FA.JustBlog.Core.Common;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult Index()
        {
            var result = uow.CategoryRepository.GetAll();
            return View(result.ToList());
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryManagerController/Edit/5
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