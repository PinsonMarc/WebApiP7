using Microsoft.AspNetCore.Mvc;

namespace Dot.Net.PoseidonApi.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Home()
        {
            return Ok("Home");
        }

        [HttpGet("/Admin/Home")]
        public IActionResult Admin()
        {
            return View("/bidList/list");
        }
    }
}