using Microsoft.AspNetCore.Mvc;

namespace REST_Test.API.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
