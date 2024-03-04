using Microsoft.AspNetCore.Mvc;

namespace REST_Test.API.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
