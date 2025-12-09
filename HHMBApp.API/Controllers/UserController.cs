using HHMBApp.Application.DTOs.User;
using HHMBApp.Application.Interfaces;
using HHMBApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HHMBApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Get user by ID
        // Get user by Username
        // Get users from household by household ID
        // Join user to household

        // TODO: Change password

        [HttpGet("getuserbyid")]
        public async Task<ActionResult<User?>> GetUserById([FromQuery] Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest();
            }
            var user = await _userService.GetUser(userId);
            if (user == null)
            {
                return NotFound();
            }
            user.Password = string.Empty;
            return Ok(user);
        }

        [HttpGet("getuserbyusername")]
        public async Task<ActionResult<User?>> GetUserByUsername([FromBody] GetUserDto request)
        {
            if (string.IsNullOrEmpty(request.username))
            {
                return BadRequest();
            }
            var user = await _userService.GetUser(request);
            if (user == null)
            {
                return NotFound();
            }
            user.Password = string.Empty;
            return Ok(user);
        }

        [HttpGet("getusersfromhousehold")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersFromHousehold([FromQuery] Guid householdId)
        {
            if (householdId == Guid.Empty)
            {
                return BadRequest();
            }
            var users = await _userService.GetUsersFromHousehold(householdId);
            foreach (User user in users)
            {
                user.Password = string.Empty;
            }
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<User?>> JoinUserToHousehold([FromBody] JoinUserHouseholdDto request)
        {
            if (request.UserId == Guid.Empty || request.HouseholdId == Guid.Empty)
            {
                return BadRequest();
            }
            var user = await _userService.JoinHousehold(request);
            if (user == null)
            {
                return NotFound();
            }
            user.Password = string.Empty;
            return Ok(user);
        }
    }
}
