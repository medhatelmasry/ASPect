using System;
using System.Threading.Tasks;
using ASPectLibrary;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

public class AuthController : Controller {
  private readonly UserManager<ApplicationUser> _userManager;
  private readonly IConfiguration _configuration;

  public AuthController(UserManager<ApplicationUser> userManager, IConfiguration configuration) {
    _userManager = userManager;
    _configuration = configuration;
  }

  [Route("register")]
  [HttpPost]
  public async Task<ActionResult> InsertUser([FromBody] RegisterViewModel model) {
    var user = new ApplicationUser {
      Email = model.Email,
      UserName = model.Email,
      FirstName = model.FirstName,
      LastName = model.LastName,
      SecurityStamp = Guid.NewGuid().ToString()
    };
    var result = await _userManager.CreateAsync(user, model.Password);
    // if (result.Succeeded) {
    //   await _userManager.AddToRoleAsync(user, "Customer");
    // }
    return Ok(new {Username = user.UserName});
  }
}
