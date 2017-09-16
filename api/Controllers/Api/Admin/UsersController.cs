using Microsoft.AspNetCore.Mvc;
using api.Controllers;
using System.Threading.Tasks;
using System.Collections.Generic;
using api.Database.Models;
using api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers.Api.Admin
{
  [Authorize]
  [Route("api/admin/[controller]")]
  public class UsersController : BaseController
  {
    public UsersController (ApplicationDbContext dbContext): base(dbContext) {}
    
    public async Task<IEnumerable<User>> Index () {
      var user = await GetCurrentUser();     
      return await db.Users.ToListAsync();
    }
  }
}