using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KiraNet.Camellia.ApiService.Controllers
{
    [Authorize/*(AuthenticationSchemes = "Bearer")*/]
    [Route("api/[controller]/[action]")]
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult GetUser()
        {
            return Json(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}
    