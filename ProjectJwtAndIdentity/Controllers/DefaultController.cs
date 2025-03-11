using Microsoft.AspNetCore.Mvc;
using ProjectJwtAndIdentity.JWTTools;
using ProjectJwtAndIdentity.Models;

namespace ProjectJwtAndIdentity.Controllers;
public class DefaultController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(ResultAppUser resultAppUser)
    {
        var value = JwtTokenGenerator.GenerateToken(resultAppUser);
        ViewBag.tokenData = value.Token;
        return View();
    }
}
