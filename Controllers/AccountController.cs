using CourseWork.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Redirect("/Identity/Account/Login"); // Перенаправление на страницу логина
    }
}
