using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PoseidonApi.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoseidonApi.Controllers
{
    //Adminstrator OPtions
    [Route("[controller]")]
    [Authorize(Roles = "Administrator")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        public UserController(UserManager<ApiUser> userManager, ILogger<UserController> logger, IMapper mapper)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Registration Attempt for {userDTO.UserName} ");

            userDTO.Id = null;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = _mapper.Map<ApiUser>(userDTO);
                var result = await _userManager.CreateAsync(user, userDTO.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                //can only register with role "USER"
                await _userManager.AddToRoleAsync(user, "User");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
                return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500);
            }
        }

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string Id)
        {
            _logger.LogInformation($"Delete attempt for user : {Id} ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _userManager.FindByIdAsync(Id);

                if (result == null) return NotFound();

                await _userManager.DeleteAsync(result);
                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Delete)}");
                return Problem($"Something Went Wrong in the {nameof(Delete)}", statusCode: 500);
            }
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUserList()
        {
            _logger.LogInformation($"Getting user list");

            try
            {
                var result = await _userManager.GetUsersInRoleAsync("User");
                var users = _mapper.Map<IList<ApiUser>, IList<UserDTO>>(result);
                foreach (var user in users)
                    user.Role = "User";

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetUserList)}");
                return Problem($"Something Went Wrong in the {nameof(GetUserList)}", statusCode: 500);
            }
        }
    }
}
