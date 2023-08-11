using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZHotel.DataAccess.Contexts;
using NZHotel.DataAccess.Entities;
using NZHotel.UI.Models;
using System.Data;
using System.Threading.Tasks;

namespace NZHotel.UI.Areas.Reception.Controllers
{
    [Area("Reception")]
    [Authorize(Roles = "Reception")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ProjectContext _context;

        public ProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ProjectContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ChangePassword()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("LogIn","Account");
                }

                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View();
                }
                await _signInManager.RefreshSignInAsync(user);
                TempData["success"] = "Your password has been successfully changed!";
                return RedirectToAction("Index", "Home");

            }
            return View(model);
        }


    }
}
