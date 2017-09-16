using System.Threading.Tasks;
using api.Controllers;
using api.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Api
{
  [Authorize]
  [Route("api/[controller]")]
  public class InitController : BaseController
  {
    public InitController (ApplicationDbContext dbContext): base(dbContext) {}

    public async Task<object> Index () {
      var user = await GetCurrentUser();
      return new {
        CurrentUser = user
      };
    }
  }
}
