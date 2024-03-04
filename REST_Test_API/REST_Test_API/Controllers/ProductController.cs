using Microsoft.AspNetCore.Mvc;

namespace REST_Test.API.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
