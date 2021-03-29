using System;
using System.Threading.Tasks;
using ASPectLibrary;
using Microsoft.AspNetCore.Identity;
using Web.Data;

public class IdentityDummyData {
    public static async Task Initialize(ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager)
    {
      context.Database.EnsureCreated();

      string teacherRole = "Teacher";
      string teacherDesc = "This is the Teacher role";

      string studentRole = "Student";
      string studentDesc = "This is the Student role";

      string password4all = "P@$$w0rd";

      if (await roleManager.FindByNameAsync(teacherRole) == null) {
        await roleManager.CreateAsync(new ApplicationRole(teacherRole, teacherDesc, DateTime.Now));
      }
      
      if (await roleManager.FindByNameAsync(studentRole) == null) {
        await roleManager.CreateAsync(new ApplicationRole(studentRole, studentDesc, DateTime.Now));
      }

      if (await userManager.FindByNameAsync("aa@aa.aa") == null) {
          var user = new ApplicationUser {
            UserName = "aa@aa.aa",
            Email = "aa@aa.aa",
            FirstName = "Adam",
            LastName = "Aldridge",
            PhoneNumber = "6902341234"
          };

          var result = await userManager.CreateAsync(user);
          if (result.Succeeded) {
            await userManager.AddPasswordAsync(user, password4all);
            await userManager.AddToRoleAsync(user, teacherRole);
          }
      }

      if (await userManager.FindByNameAsync("bb@bb.bb") == null) {
          var user = new ApplicationUser {
            UserName = "bb@bb.bb",
            Email = "bb@bb.bb",
            FirstName = "Bob",
            LastName = "Barker",
            PhoneNumber = "7788951456"
          };

          var result = await userManager.CreateAsync(user);
          if (result.Succeeded) {
            await userManager.AddPasswordAsync(user, password4all);
            await userManager.AddToRoleAsync(user, teacherRole);
          }
      }

      if (await userManager.FindByNameAsync("mm@mm.mm") == null) {
          var user = new ApplicationUser {
            UserName = "mm@mm.mm",
            Email = "mm@mm.mm",
            FirstName = "Mike",
            LastName = "Myers",
            PhoneNumber = "6572136821"
          };

          var result = await userManager.CreateAsync(user);
          if (result.Succeeded) {
            await userManager.AddPasswordAsync(user, password4all);
            await userManager.AddToRoleAsync(user, studentRole);
          }
      }

      if (await userManager.FindByNameAsync("dd@dd.dd") == null) {
          var user = new ApplicationUser {
            UserName = "dd@dd.dd",
            Email = "dd@dd.dd",
            FirstName = "Donald",
            LastName = "Duck",
            PhoneNumber = "6041234567"
          };

          var result = await userManager.CreateAsync(user);
          if (result.Succeeded) {
            await userManager.AddPasswordAsync(user, password4all);
            await userManager.AddToRoleAsync(user, studentRole);
          }
      }
    }
}
  
