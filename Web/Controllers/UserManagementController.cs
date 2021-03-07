using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Controllers;
using Web.Data;
using Web.ViewModels;
using Web.Models;
using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Web.CmsControllers
{
    [Authorize(Roles = Constants.Account.ADMIN_ROLE_NAME)]
    public class UserManagementController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration; //dependency injection

        public UserManagementController(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration config)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = config;
        }

        // GET: UserRoleViewModels
        public async Task<IActionResult> Index()
        {
            var models = new List<UserRoleViewModel>();

            foreach (IdentityUser identityUser in _context.Users.ToList())
            {
                if (_context.UserRoles.Count() > 0)
                {
                    IdentityUserRole<string> identityUserRole = _context.UserRoles
                    .Where(userRole => userRole.UserId == identityUser.Id)
                    .First();

                    IdentityRole identityRole = await _roleManager
                        .FindByIdAsync(identityUserRole.RoleId)
                        .ConfigureAwait(false);

                    models.Add(new UserRoleViewModel()
                    {
                        IdentityUser = identityUser,
                        IdentityRole = identityRole,
                    });
                }
                else
                {
                    models.Add(new UserRoleViewModel()
                    {
                        IdentityUser = identityUser,
                    });
                }
            }

            return View(models);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roles = _context.Roles.ToList();

            IdentityUser identityUser = _context.Users.Where(user => user.UserName == id).First();

            UserRoleViewModel model;
            IdentityRole identityRole = null;
            if (_context.UserRoles.Count() > 0)
            {
                IdentityUserRole<string> identityUserRole = _context.UserRoles
                    .Where(userRole => userRole.UserId == identityUser.Id)
                    .First();

                identityRole = await _roleManager
                       .FindByIdAsync(identityUserRole.RoleId)
                       .ConfigureAwait(false);

                model = new UserRoleViewModel
                {
                    IdentityUserID = identityUser.Id,
                    IdentityUser = identityUser,
                    IdentityRoleID = identityRole.Id,
                    IdentityRole = identityRole,
                };
            }
            else
            {
                model = new UserRoleViewModel
                {
                    IdentityUserID = identityUser.Id,
                    IdentityUser = identityUser,
                };
            }

            var selectItemListRoles = new List<SelectListItem>();

            foreach (var role in _context.Roles.ToList())
            {
                selectItemListRoles.Add(new SelectListItem(role.Name, role.Id, role.Id == identityRole.Id));
            }

            ViewBag.Roles = selectItemListRoles;
            ViewBag.Role = identityRole;

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        /// <summary>
        /// Updates user role
        /// </summary>
        /// <param name="userRoleViewModel">IdentityRole contains the new role</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserRoleViewModel userRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                var identityUser = await _userManager.FindByIdAsync(userRoleViewModel.IdentityUserID);

                if (identityUser.UserName != Constants.Account.ADMIN_USER_NAME)
                {
                    var rolesNameList = await _userManager.GetRolesAsync(identityUser);
                    await _userManager.RemoveFromRolesAsync(identityUser, rolesNameList.ToArray());

                    var newRole = await _roleManager.FindByIdAsync(userRoleViewModel.IdentityRole.Id);
                    await _userManager.AddToRoleAsync(identityUser, newRole.Name);

                    // Refresh cookies if current user is not Admin since cookies stores user
                    var currentUser = await _userManager.GetUserAsync(HttpContext.User).ConfigureAwait(false);
                    var userRoles = await _userManager.GetRolesAsync(currentUser).ConfigureAwait(false);
                    var userRole = userRoles.First(); // Only one
                    if (userRole != Constants.Account.ADMIN_ROLE_NAME)
                    {
                        await _signInManager.RefreshSignInAsync(
                            await _userManager.GetUserAsync(HttpContext.User)
                            .ConfigureAwait(false)
                        ).ConfigureAwait(false);

                        return RedirectToAction(nameof(Index), nameof(HomeController));
                    }

                    return RedirectToAction(nameof(Index));
                }
            }

            return View(userRoleViewModel);
        }

        // POST: Elections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _context.Users.FindAsync(id);

            if (_context.UserRoles.Count() > 0)
            {
                var tempUserRole = _context.UserRoles.Where(userRole => userRole.UserId == id).First();
                _context.UserRoles.Remove(tempUserRole);
            }

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Route("register")] //register endpoint, adds user. route: ' /register ' 
        [HttpPost]
        public async Task<ActionResult> InsertUser([FromBody] RegisterViewModel model)
        {
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            { //if the user has indeed been created
                await _userManager.AddToRoleAsync(user, "Student"); //add the user to "Student" role
            }
            return Ok(new { Username = user.UserName });
        }
        [Route("login")] // route: ' /login '
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var claim = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
                    };
                var signinKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));

                int expiryInMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryInMinutes"]);

                var token = new JwtSecurityToken(
                  issuer: _configuration["Jwt:Site"],
                  audience: _configuration["Jwt:Site"],
                  expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                  signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok(
                  new
                  {
                      token = new JwtSecurityTokenHandler().WriteToken(token),
                      expiration = token.ValidTo
                  });
            }
            return Unauthorized();
        }
    }
}