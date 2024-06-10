using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    public class TopBusinessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
