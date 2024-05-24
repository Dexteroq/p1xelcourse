using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View("Courses");
        }
    }
}
