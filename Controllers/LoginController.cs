using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View("Login");
        }
    }
}
