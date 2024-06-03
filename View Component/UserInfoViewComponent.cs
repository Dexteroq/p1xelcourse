using CourseWork.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Coursework
{
    public class UserInfoViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserInfoViewComponent(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string displayType)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                if (displayType == "name")
                {
                    ViewData["UserInfo"] = $"{user.FirstName} {user.LastName}";
                }
                else if (displayType == "email")
                {
                    ViewData["UserInfo"] = user.Email;
                }
                else
                {
                    ViewData["UserInfo"] = "Invalid display type";
                }
            }

            return View();
        }

    }
}
