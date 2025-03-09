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
    public async Task<IActionResult> Index(RegisterViewModel model) //buradaki register create işlemi aspnetusers tablosuna kayıt atıyor.
    {
        AppUser appUser = new AppUser()
        {
            Name = model.Name,
            Surname = model.SurName,
            UserName = model.UserName,
            Email = model.Email
        }; //CreateAsync pssword db kayıt ederken hash liyor. o yüzden üstteki appuser model de atama yapmadık diğerleri gibi.
        await _userManager.CreateAsync(appUser, model.Password); 
        return RedirectToAction("RoleList", "Role");
    }
}
