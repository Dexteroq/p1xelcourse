using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
