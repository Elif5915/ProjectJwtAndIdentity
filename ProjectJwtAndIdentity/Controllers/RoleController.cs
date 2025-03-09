using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectJwtAndIdentity.Entities;
using ProjectJwtAndIdentity.Models;

namespace ProjectJwtAndIdentity.Controllers;
public class RoleController : Controller
{
    private readonly RoleManager<AppRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;

    public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public IActionResult RoleList()
    {
        var values = _roleManager.Roles.ToList();
        return View(values);
    }

    [HttpGet]
    public IActionResult CreateRole()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole(CreateRoleViewModel model) //aspnetRoles tablosuna kayıt atıyoruz
    {
        AppRole appRole = new AppRole() //AppRole sınıfından bir nesne örneği aldık
        {
            Name = model.RoleName
        };
        await _roleManager.CreateAsync(appRole); //bu ekleme işlemimi gerçekleştirecek
        return RedirectToAction("RoleList");
    }

    public async Task<IActionResult> DeleteRole(int id)
    {
        var value = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
        await _roleManager.DeleteAsync(value);
        //savechanges gerek yok çünkü kendisi otomatik kayıt işlemi yapıyor.
        return RedirectToAction("RoleList");

    }

    public IActionResult UserList()
    {
        var values = _userManager.Users.ToList();
        return View(values);
    }

    [HttpGet]
    public async Task<IActionResult> AssignRole(int id) //kullanıcının id si 
    {
        //önce kullanıcı al
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
        TempData["x"] = user.Id; //tempdata geçici bir değer iki controller arasında değer taşımak istediğimiz için tempdata kullandık.
        //tüm rolleri al
        var roles =  _roleManager.Roles.ToList();
        //kullanıcın sahip olduğu rolleri al
        var userRoles = await _userManager.GetRolesAsync(user);

        List<RoleAssignViewModel> rolesAssignViewModels = new List<RoleAssignViewModel>(); //bu başlangıçta boş liste döndürüyor
        foreach (var item in roles)
        {
            RoleAssignViewModel model = new RoleAssignViewModel();
            model.RoleId = item.Id;
            model.RoleName = item.Name;
            model.RoleExist = userRoles.Contains(item.Name);
            rolesAssignViewModels.Add(model); //burada boş liste dolduruyoruz.

        }
        //67.satır ile 70.satır daki kodlar arasında ne fark var?
        //67.satırda tüm modeldekilerilisteledik.70.satırda ise foreach içinde ise tüm
        //listeden gelenlere tek tek değer atamış olmuş. 
        return View(rolesAssignViewModels);
    }
    [HttpPost]
    public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)//liste olarak almamızın sebebi modeli; bir kullanıcının birden fazla rolü olabilir çünkü
    {
        var userId = (int)TempData["x"];
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
        foreach (var item in model)
        {
            if (item.RoleExist)
            {
                await _userManager.AddToRoleAsync(user,item.RoleName);
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, item.RoleName);
            }
        }
        return RedirectToAction("UserList");
    } 

}
