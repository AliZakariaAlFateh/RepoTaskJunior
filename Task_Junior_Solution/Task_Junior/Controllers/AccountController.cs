using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using Task_Junior.ViewModel;

namespace Task_Junior.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]

        public IActionResult Register()
        {
            var roles = roleManager.Roles.Select(r => new SelectListItem
            {
                Value = r.Name,
                Text = r.Name
            }).ToList();

            ViewBag.Roles = roles;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserVM user)
        {
            if (ModelState.IsValid)
            {
                IdentityUser newUser = new IdentityUser();
                newUser.UserName = user.UserName;
                newUser.Email = user.Email;
                IdentityResult result = await userManager.CreateAsync(newUser, user.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(newUser,false);//create cookie until close browser
                    if(user.RoleName=="Admin")
                        await userManager.AddToRoleAsync(newUser, user.RoleName);
                    else
                        await userManager.AddToRoleAsync(newUser,user.RoleName );

                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    var roles = roleManager.Roles.Select(r => new SelectListItem
                    {
                        Value = r.Name,
                        Text = r.Name
                    }).ToList();
                    ViewBag.Roles = roles;
                    return View(user);
                }
            }
            else
            {

                var roles = roleManager.Roles.Select(r => new SelectListItem
                {
                    Value = r.Name,
                    Text = r.Name
                }).ToList();

                ViewBag.Roles = roles;
                return View(user);
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM userLogin)
        {
            if (ModelState.IsValid)
            {
                IdentityUser User = await userManager.FindByNameAsync(userLogin.UserName);
                if (User != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result =
                        await signInManager.PasswordSignInAsync(User, userLogin.Password, userLogin.RememberMe, false);    
                    if (result.Succeeded)
                    {
                        return RedirectToAction("ShowProductsForClients","Product");
                    }
                    else
                        ModelState.AddModelError("Password", "UserName or Password Not Correct");
                }
                else
                {
                    ModelState.AddModelError("", "UserName or Password Not Correct");
                }
            }
            return View(userLogin);
        }

        public async Task<IActionResult> LogOut()
        {
       
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");

        }

    }
}
