using HHMBApp.Application.DTOs.User;
using HHMBApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace HHMBApp.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("api/auth/register")]
        public async Task<ActionResult<CreateUserResponseDto>> Register(CreateUserDto userDto)
        {
            var result = await _userService.AddUser(userDto);
            if (result.Result == CreateUserResult.OK)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("api/auth/login")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginRequestDto loginRequest)
        {
            var result = await _userService.Login(loginRequest);
            if (result.Result == LoginResponseStatus.OK)
            {
                return Ok(result);
            }
            return Unauthorized(result);
        }

        // TODO: Add change password
    }
}
