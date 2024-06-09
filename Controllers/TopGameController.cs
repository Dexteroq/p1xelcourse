using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    public class TopGameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
