using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    public class TopicJSController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
