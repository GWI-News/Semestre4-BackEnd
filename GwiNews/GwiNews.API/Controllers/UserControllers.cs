using GwiNews.Application.DTOs;
using GwiNews.Application.Interfaces;
using GwiNews.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GwiNews.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            var users = await _userService.GetUsersAsync();
            if (users == null || !users.Any())
            {
                return NotFound("Users not found");
            }
            return Ok(users);
        }

        [HttpGet("{id:guid}", Name = "GetUser")]
        public async Task<ActionResult<UserDTO>> Get(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDTO userDto)
        {
            if (userDto == null)
                return BadRequest("Invalid data");

            await _userService.AddUserAsync(userDto);

            return CreatedAtRoute("GetUser",
                new { id = userDto.Id }, userDto);
        }

        [HttpPut("{id:guid}", Name = "UpdateUser")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UserDTO userDto)
        {
            if (id != userDto.Id)
            {
                return BadRequest("User ID mismatch");
            }

            if (userDto == null)
                return BadRequest("Invalid data");

            await _userService.UpdateUserAsync(userDto);

            return Ok(userDto);
        }

        [HttpDelete("{id:guid}", Name = "DeleteUser")]
        public async Task<ActionResult<UserDTO>> Delete(Guid id)
        {
            var userDto = await _userService.GetUserByIdAsync(id);

            if (userDto == null)
            {
                return NotFound("User not found");
            }

            await _userService.RemoveUserAsync(id);

            return Ok(userDto);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetFiltered([FromQuery] string? name, [FromQuery] UserRole? role)
        {
            var users = await _userService.GetFilteredUsersAsync(name, role);
            if (users == null || !users.Any())
            {
                return NotFound("No users found with the specified filters");
            }
            return Ok(users);
        }

        [HttpGet("{id:guid}/status", Name = "GetUserStatus")]
        public async Task<ActionResult<bool>> GetStatus(Guid id)
        {
            var status = await _userService.GetUserStatusAsync(id);
            if (status == null)
            {
                return NotFound("User not found");
            }
            return Ok(status);
        }

        [HttpPut("{id:guid}/status", Name = "UpdateUserStatus")]
        public async Task<ActionResult> UpdateStatus(Guid id, [FromBody] bool newStatus)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            await _userService.UpdateUserStatusAsync(id, newStatus);
            return Ok($"User status updated to {newStatus}");
        }
    }
}
