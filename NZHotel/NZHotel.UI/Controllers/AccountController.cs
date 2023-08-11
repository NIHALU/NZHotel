using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZHotel.DataAccess.Entities;
using NZHotel.UI.Areas.Management.Models;
using NZHotel.UI.Models;

namespace NZHotel.UI.Areas.Management.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;    
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
           
        }




        public IActionResult LogIn(string returnUrl)
        {

            return View(new UserSignInModel() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(UserSignInModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                var signInResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);
                //signInResult needs to return as (succeeded, IsLockedOut,IsNotAllowed vs.) IsNotAllowed means email is not confirmed)

                if (signInResult.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Contains("Manager"))
                    {
                        return Redirect("/Management/Home/Index");
                    }
                    else
                    {
                        return Redirect("/Reception/Home/Index");
                    }
                }
                else if (signInResult.IsLockedOut)
                {

                    var lockOutEnd = await _userManager.GetLockoutEndDateAsync(user);  //when account locked out, it says that how long account will lock out
                    ModelState.AddModelError("", $"Your account will be {(lockOutEnd.Value.UtcDateTime - DateTime.UtcNow).Minutes} minutes locked!");
                }
                else
                {
                    var message = string.Empty;
                    if (user != null)
                    {
                        var failedCount = await _userManager.GetAccessFailedCountAsync(user);
                        message = $"Your account will be temporarily locked after {(_userManager.Options.Lockout.MaxFailedAccessAttempts - failedCount)} incorret login attempts! ";
                    }
                    else
                    {
                        message = "Username or Password is wrong!";
                    }
                    ModelState.AddModelError("", message);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Account/SignIn");
        }

		public IActionResult ChangePassword()
		{

            return View();
		}

		
		


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
