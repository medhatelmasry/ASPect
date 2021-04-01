using ASPectLibrary;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class UserRoleViewModel
    {
        [Display(Name = "User ID")]
        public string IdentityUserID { get; set; }

        [Display(Name = "Username")]
        public ApplicationUser IdentityUser { get; set; }

        [Display(Name = "Role ID")]
        public string IdentityRoleID { get; set; }

        [Display(Name = "Role")]
        public ApplicationRole IdentityRole { get; set; }
    }
}