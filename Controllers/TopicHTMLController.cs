using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    public class TopicHTMLController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
