using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    public class TopDesignController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
