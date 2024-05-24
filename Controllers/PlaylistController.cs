using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    public class PlaylistController : Controller
    {
        public IActionResult Index()
        {
            return View("Playlist");
        }
    }
}
