using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
