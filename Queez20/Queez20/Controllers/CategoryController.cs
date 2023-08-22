using Microsoft.AspNetCore.Mvc;

namespace Queez20.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
