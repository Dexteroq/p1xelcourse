using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    public class WatchVideo2Controller : Controller
    {
        public IActionResult Index()
        {
            return View("Watch2");
        }
    }
}
