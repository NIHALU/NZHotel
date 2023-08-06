using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZHotel.DataAccess.Entities;
using NZHotel.UI.Areas.Management.Models;

namespace NZHotel.UI.Areas.Admin.Controllers
{

    [Area("Management")]
  
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult AccessDenied()
        {
            return View();
        }



        [Authorize(Roles = "Manager")]
        public IActionResult Index()
        {
            return View();
        }


    }
}
