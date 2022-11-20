using PoseidonApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PoseidonApi.Model.Identity;
using PoseidonApi.Services;
using System;
using System.Threading.Tasks;

namespace PoseidonApi.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IAuthManager _authManager;

        public LoginController(ILogger<LoginController> logger, IAuthManager authManager)
        {
            _logger = logger;
            _authManager = authManager;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userDTO)
        {
            _logger.LogInformation($"Login Attempt for {userDTO.UserName} ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (!await _authManager.ValidateUser(userDTO))
                {
                    return Unauthorized();
                }

                return Accepted(new TokenRequest { Token = await _authManager.CreateToken(), RefreshToken = await _authManager.CreateRefreshToken() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Login)}");
                return Problem($"Something Went Wrong in the {nameof(Login)}", statusCode: 500);
            }
        }

        [HttpPost("/refreshtoken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest request)
        {
            var tokenRequest = await _authManager.VerifyRefreshToken(request);
            if(tokenRequest is null)
            {
                return Unauthorized();
            }

            return Ok(tokenRequest);
        }

        [HttpGet("/error")]
        public IActionResult Error()
        {
            string errorMessage = "You are not authorized for the requested data.";

            return Unauthorized(errorMessage);
        }
    }
}