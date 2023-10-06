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
        //create objects by using Dependency injection
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpGet]

        public IActionResult Register() 
        {
            var roles = roleManager.Roles.Select(r => new SelectListItem
            {
                Value = r.Name,
                Text = r.Name
            }).ToList();
            //select Role from database to show in dropdown list and give user to select his role in web site

            ViewBag.Roles = roles;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserVM user)
        {
            if (ModelState.IsValid)
            { //add user
                IdentityUser newUser = new IdentityUser();
                newUser.UserName = user.UserName;
                newUser.Email = user.Email;
                //chech user is exist or not and if not exist create user and value of result will be success
                IdentityResult result = await userManager.CreateAsync(newUser, user.Password);  // create user in database and hash password
                

                if (result.Succeeded) //if true=success create cookie in browser 
                {
                    await signInManager.SignInAsync(newUser,false);// falsse ==create cookie until close browser
                    if(user.RoleName=="Admin") //assign ROle to user Registerv
                        await userManager.AddToRoleAsync(newUser, user.RoleName);
                    else
                        await userManager.AddToRoleAsync(newUser,user.RoleName );

                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var item in result.Errors) //if result  is failed will return Description of the errror to register
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    var roles = roleManager.Roles.Select(r => new SelectListItem
                    {
                        Value = r.Name,
                        Text = r.Name
                    }).ToList(); //get roles from databse again because viewbag single response request  so will sent again
                    ViewBag.Roles = roles;
                    return View(user);//return data to register form if not success
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
                IdentityUser User = await userManager.FindByNameAsync(userLogin.UserName); //get user by username
                if (User != null)
                {
                    //check on password when user is exist 
                    Microsoft.AspNetCore.Identity.SignInResult result =
                        await signInManager.PasswordSignInAsync(User, userLogin.Password, userLogin.RememberMe, false);
                    //in case password and user is vaild  will create cookie and redirect to page ShowProductsForClients
                    if (result.Succeeded) 
                    {
                        return RedirectToAction("ShowProductsForClients","Product");
                    }
                    else
                        ModelState.AddModelError("Password", "UserName or Password Not Correct"); //return error if username or password is Wrong
                }
                else
                {
                    ModelState.AddModelError("", "UserName or Password Not Correct");//return error if  user not Exist
                }
            }
            return View(userLogin); //return data in case modelstae is invalid
        }

        public async Task<IActionResult> LogOut()
        {
       
            await signInManager.SignOutAsync(); //destory cookie for login user
            return RedirectToAction("Login"); //redirect to login page

        }

    }
}
