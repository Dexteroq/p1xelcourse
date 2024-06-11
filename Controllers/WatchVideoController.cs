using CourseWork.Data;
using CourseWork.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Controllers
{
    public class WatchVideoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WatchVideoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Watch()
        {
            var comments = await _context.Comments
                .Include(c => c.User)
                .ToListAsync();

            var viewModel = new VideoViewModel
            {
                Comments = comments
            };

            return View(viewModel);
        }
    }
}
