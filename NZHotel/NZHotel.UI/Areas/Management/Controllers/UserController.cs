using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NZHotel.DataAccess.Contexts;
using NZHotel.DataAccess.Entities;
using NZHotel.UI.Areas.Management.Models;

namespace NZHotel.UI.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Roles = "Manager")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly ProjectContext _context;

        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, ProjectContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<IActionResult> List()
        {
            List < AppUser > filteredUsers = new List<AppUser>();
            var users = _userManager.Users.ToList();
            
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                //if (!roles.Contains("Manager"))
                //{
                //    filteredUsers.Add(user);
                //}
                filteredUsers.Add(user);
            }

            return View(filteredUsers);
        }

        public IActionResult Create()
        {
            var list = _roleManager.Roles.ToList();

            UserCreateModel model = new UserCreateModel()
            {
                Roles = new SelectList(list, "Id", "Name")
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };
                var identityResult = await _userManager.CreateAsync(user, model.UserName + "123");  

                if (identityResult.Succeeded)
                {
                    var appRole = await _roleManager.FindByIdAsync(model.RoleId.ToString());
                    var role = await _roleManager.FindByNameAsync(appRole.Name);
                    if (role == null)  ///eğer member diye bir rol yoksa önce member adında bir role yarat 
                    {
                        await _roleManager.CreateAsync(new()
                        {
                            Name = appRole.Name,
                        });
                    }
                    await _userManager.AddToRoleAsync(user, appRole.Name);
                    return RedirectToAction("List");
                }
                foreach (var item in identityResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.SingleOrDefault(x => x.Id == id);
            var userRoles = await _userManager.GetRolesAsync(user);
            var roles = _roleManager.Roles.ToList();

            RoleAssignSendModel model = new RoleAssignSendModel();

            List<RoleAssignListModel> list = new List<RoleAssignListModel>();

            foreach (var role in roles)
            {
                list.Add(new()
                {
                    RoleName = role.Name,
                    RoleId = role.Id,
                    Exist = userRoles.Contains(role.Name)
                });
            }

            model.Roles = list;
            model.UserId = id;
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(RoleAssignSendModel model)
        {
            //role ekleme => seçilen rolün userda olmaması gerek
            //role cıkarma => seçilen rolün olması 

            var user = _userManager.Users.SingleOrDefault(x => x.Id == model.UserId);

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var role in model.Roles)
            {
                if (role.Exist)    //ekleme yapma yani role.Exist true
                {
                    if (!userRoles.Contains(role.RoleName))   //seçilen rolün olmaması gerek
                    {
                        await _userManager.AddToRoleAsync(user, role.RoleName);
                    }
                }
                else    //role çıkarma
                {
                    if (userRoles.Contains(role.RoleName))
                    {
                        await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                    }
                }
            }

            return RedirectToAction("List");
        }
    }
}
