using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Api
{
  [Route("api/[controller]")]
  public class CarsController : Controller
  {
    public IEnumerable<object> Index () {
      return new object[] {
        new { Id = 1, Name = "Carlos" },
        new { Id = 2, Name = "Michael" }
      };
    }
  }
}