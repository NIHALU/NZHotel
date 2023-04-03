using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZHotel.DataAccess.Entities;
using NZHotel.UI.Areas.Management.Models;

namespace NZHotel.UI.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize(Roles = "Manager")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }


        public IActionResult List()
        {
            var list = _roleManager.Roles.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View(new RoleCreateModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new AppRole
                {
                    Name = model.Name
                });

                if (result.Succeeded)
                {
                    return RedirectToAction("List");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Update(int roleId)
        {
          var appRole= await _roleManager.FindByIdAsync(roleId.ToString());
            RoleUpdateModel model = new RoleUpdateModel()
            {
                Id = roleId,
                Name = appRole.Name,
                ConcurrencyStamp = appRole.ConcurrencyStamp,

            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoleUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                AppRole appRole = new AppRole()
                {
                    Name = model.Name,
                    Id = model.Id,
                    ConcurrencyStamp = model.ConcurrencyStamp,


                };

              var result= await _roleManager.UpdateAsync(appRole);
                if(result.Succeeded)
                {
                    return RedirectToAction("List");
                }
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }


    }
}
