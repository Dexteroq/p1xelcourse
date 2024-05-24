using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View("Contact");
        }
    }
}
