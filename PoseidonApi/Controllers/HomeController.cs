using Microsoft.AspNetCore.Mvc;

namespace Dot.Net.PoseidonApi.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Home()
        {
            return Ok("Created by Marc Pinson using asp.net core");
        }

        [HttpGet("/Admin/Home")]
        public IActionResult Admin()
        {
            return View("/bidList/list");
        }
    }
}