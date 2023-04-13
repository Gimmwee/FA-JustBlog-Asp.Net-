using FA.JustBlog.Core.Repository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Controllers
{
    public class PostController : Controller
    {
        private IUnitOfWork uow;
        public PostController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        //public ActionResult Index(int? page)
        //{

        //    // 1. Tham số int? dùng để thể hiện null và kiểu int
        //    // page có thể có giá trị là null và kiểu int.

        //    // 2. Nếu page = null thì đặt lại là 1.
        //    if (page == null) page = 1;

        //    // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
        //    // theo LinkID mới có thể phân trang.
        //    var posts = (from p in uow.PostRepository.FindPost()
        //                 select p).OrderBy(x => x.LinkID);

        //    // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
        //    int pageSize = 3;

        //    // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
        //    // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
        //    int pageNumber = (page ?? 1);

        //    // 5. Trả về các Link được phân trang theo kích thước và số trang.
        //    return View(posts.ToPagedList(pageNumber, pageSize));
        //}

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
                var result = uow.PostRepository.Find(pid.Value);
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
