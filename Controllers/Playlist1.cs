using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    public class Playlist1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
