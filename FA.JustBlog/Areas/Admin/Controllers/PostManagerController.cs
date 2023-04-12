using FA.JustBlog.Core.Repository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult Index()
        {
            var result = uow.PostRepository.GetAll();
            return View(result.ToList());
        }

        // GET: PostManagerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostManagerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: PostManagerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PostManagerController/Edit/5
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

        // GET: PostManagerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostManagerController/Delete/5
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
