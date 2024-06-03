using CourseWork.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class UserInfoViewComponent : ViewComponent
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserInfoViewComponent(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (user != null)
        {
            string fullName = $"{user.FirstName} {user.LastName}";
            ViewData["UserName"] = fullName;
            ViewData["UserEmail"] = user.Email;
        }

        return View();
    }
}
