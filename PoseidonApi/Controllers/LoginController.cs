using Dot.Net.PoseidonApi.Entities;
using Dot.Net.PoseidonApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Dot.Net.PoseidonApi.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private UserRepository _userRepository;

        public LoginController(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View("login");
        }

        [HttpGet("/secure/article-details")]
        public IActionResult GetAllUserArticles()
        {
            return View(_userRepository.FindAll());
        }

        [HttpGet("/error")]
        public IActionResult Error()
        {
            string errorMessage = "You are not authorized for the requested data.";

            return View(new UnauthorizedObjectResult(errorMessage));
        }
    }
}