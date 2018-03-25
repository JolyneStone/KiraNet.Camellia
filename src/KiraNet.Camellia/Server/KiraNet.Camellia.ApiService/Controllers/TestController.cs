using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace KiraNet.Camellia.ApiService.Controllers
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult GetUser()
        {
            return Json(User);
        }
    }
}
    