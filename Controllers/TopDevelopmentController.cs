using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    public class TopDevelopmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
