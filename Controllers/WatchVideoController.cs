using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    public class WatchVideoController : Controller
    {
        public IActionResult Index()
        {
            return View("Watch");
        }
    }
}
