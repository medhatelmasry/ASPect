using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Models;

namespace Web.Data
{
    public class AccountsInit
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private IConfiguration _config;
        private ApplicationDbContext _context;

        public async void InitializeAsync(IApplicationBuilder app)
        {
            using (IServiceScope serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                _userManager = serviceScope.ServiceProvider.GetService<UserManager<IdentityUser>>();
                _roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                _config = serviceScope.ServiceProvider.GetService<IConfiguration>();
                _context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                if (_context.UserRoles.Count() == 0)
                {
                    await InsertUserAsync().ConfigureAwait(false);
                }
            }
        }

        public async Task InsertUserAsync()
        {
            await CreateRole(
                Constants.Account.ROLE_NAME,
                Constants.Account.ROLE_NAME);

            await AddNewUserToRole(
                Constants.Account.ADMIN_EMAIL,
                Constants.Account.ADMIN_USERNAME,
                _config["Users:DefaultAdminPassword"],
                Constants.Account.ROLE_NAME);

            await CreateRole(
                Constants.Account.STUDENT_NAME,
                Constants.Account.STUDENT_NAME);

            await AddNewUserToRole(
                Constants.Account.STUDENT_EMAIL,
                Constants.Account.STUDENT_USERNAME,
                _config["Users:DefaultStudentPassword"],
                Constants.Account.STUDENT_NAME);

            await CreateRole(
            Constants.Account.STUDENT_NAME,
            Constants.Account.STUDENT_NAME);

            await AddNewUserToRole(
                Constants.Account.INSTRUCTOR_EMAIL,
                Constants.Account.INSTRUCTOR_USERNAME,
                _config["Users:DefaultInstructorPassword"],
                Constants.Account.INSTRUCTOR_NAME);

        }

        private async Task CreateRole(string identityRoleName, string identityRoleNormalizedName)
        {
            var role = new IdentityRole { Name = identityRoleName, NormalizedName = identityRoleNormalizedName };

            if (await _roleManager.FindByNameAsync(role.Name) == null)
            {
                await _roleManager.CreateAsync(role);
            }
        }

        private async Task AddNewUserToRole(string email, string userName, string password, string role)
        {
            var user = new IdentityUser { Email = email, UserName = userName, SecurityStamp = Guid.NewGuid().ToString() };

            if ((await _userManager.CreateAsync(user, password)).Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role);
            }
        }
    }
}