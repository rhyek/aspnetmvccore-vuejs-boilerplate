using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Database;
using api.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace api.Controllers
{
  public class AccountController : Controller
  {
    ApplicationDbContext db;

    public AccountController (ApplicationDbContext dbContext) {
      db = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> Login ([FromBody] User user)
    {
      if (user == null) {
        return BadRequest("User credentials not provided.");
      }
      var found = await db.Users
        .Where(u => u.UserName == user.UserName)
        .FirstOrDefaultAsync();
      if (found?.Password != user.Password) {
        return BadRequest("Username or password is incorrect.");
      }
      
      var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
      identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
      identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, found.Id.ToString()));

      await HttpContext.SignInAsync(
        CookieAuthenticationDefaults.AuthenticationScheme,
        new ClaimsPrincipal(identity),
        new AuthenticationProperties {
          IsPersistent = true,
          ExpiresUtc = DateTime.UtcNow.AddHours(12)
        }
      );

      return new EmptyResult();
    }

    public async Task<IActionResult> Logout() {
      await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
      return new EmptyResult();
    }


    // public IActionResult Error()
    // {
    //   return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
  }
}
