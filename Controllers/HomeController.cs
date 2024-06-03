using CourseWork.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using CourseWork.Areas.Identity.Data;

namespace CourseWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Получение текущего аутентифицированного пользователя
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                // Получение имени и фамилии пользователя
                string fullName = $"{user.FirstName} {user.LastName}";

                // Передача данных пользователя в представление
                ViewData["UserName"] = fullName;
                ViewData["UserEmail"] = user.Email;
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
