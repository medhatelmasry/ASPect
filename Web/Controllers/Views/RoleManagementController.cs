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
    [Authorize(Roles = Constants.ASPectRoles.Admin.RoleName)]
    public class RoleManagementController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleManagementController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
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
                var result = await _roleManager.CreateAsync(new ApplicationRole(role.RoleName));
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var models = new List<ApplicationRole>();
            foreach (ApplicationRole identityRole in _roleManager.Roles.ToList())
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