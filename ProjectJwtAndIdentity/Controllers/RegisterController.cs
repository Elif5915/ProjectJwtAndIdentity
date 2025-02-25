using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectJwtAndIdentity.Entities;
using ProjectJwtAndIdentity.Models;

namespace ProjectJwtAndIdentity.Controllers;
public class RegisterController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(RegisterViewModel model)
    {
        AppUser appUser = new AppUser()
        {
            Name = model.Name,
            Surname = model.SurName,
            UserName = model.UserName,
            Email = model.Email
        };
        await _userManager.CreateAsync(appUser, model.Password);
        return RedirectToAction("RoleList", "Role");
    }
}
