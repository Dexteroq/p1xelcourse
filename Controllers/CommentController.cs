using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CourseWork.Data;
using CourseWork.Models;
using CourseWork.Services;
using Microsoft.AspNetCore.Identity;
using CourseWork.Areas.Identity.Data;

namespace CourseWork.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _commentContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UserService _userService;

        public CommentController(ApplicationDbContext commentContext, UserManager<ApplicationUser> userManager, UserService userService)
        {
            _commentContext = commentContext;
            _userManager = userManager;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(string text)
        {
            var user = await _userManager.GetUserAsync(User);

            var comment = new Comment
            {
                Text = text,
                UserId = user.Id,
                UserName = $"{user.FirstName} {user.LastName}" // Combine first name and last name for display
            };

            _commentContext.Comments.Add(comment);
            await _commentContext.SaveChangesAsync();

            return RedirectToAction("Watch", "WatchVideo");
        }
    }
}
