using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPectLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

namespace Web.Controllers
{
    [Authorize(Roles = Constants.Account.ADMIN_ROLE_NAME)]
    public class RoleManagementController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RoleManagementController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectRole role)
        {
            var roleExist = await _roleManager.RoleExistsAsync(role.RoleName);
            if (!roleExist)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(role.RoleName));
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var models = new List<IdentityRole>();
            foreach (IdentityRole identityRole in _roleManager.Roles.ToList())
            {
                models.Add(identityRole);
            }
            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            else
            {
                var model = new EditProjectRole
                {
                    Id = role.Id,
                    RoleName = role.Name
                };
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProjectRole editProjectRole)
        {
            var role = await _roleManager.FindByIdAsync(editProjectRole.Id);
            if (role == null)
            {
                return NotFound();
            }
            else
            {
                role.Name = editProjectRole.RoleName;
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
                }
                return View(editProjectRole);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            else
            {
                var result = await _roleManager.DeleteAsync(role);
                return RedirectToAction("Index", "Admin");
            }
        }
    }
}