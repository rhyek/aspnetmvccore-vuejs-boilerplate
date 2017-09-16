using System.Linq;
using System.Threading.Tasks;
using api.Database;
using api.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
  public class BaseController : Controller
  {
    protected ApplicationDbContext db;
    private User currentUser;

    public BaseController (ApplicationDbContext dbContext) {
      db = dbContext;
    }

    protected async Task<User> GetCurrentUser () {
      if (currentUser != null) {
        return currentUser;
      }
      if (HttpContext.User != null) {
        var name = HttpContext.User.Identity.Name;
        var user = await db.Users
          .Where(u => u.UserName == name)
          .FirstOrDefaultAsync();
        if (user != null) {
          currentUser = user;
          return user;
        }
      }
      return null;
    }
  }
}