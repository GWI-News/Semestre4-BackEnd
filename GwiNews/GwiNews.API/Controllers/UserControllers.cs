//using GwiNews.Application.DTOs;
//using GwiNews.Application.Interfaces;
//using Microsoft.AspNetCore.Mvc;

//namespace GwiNews.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : ControllerBase
//    {
//        private readonly IUserService _userService;

//        public UsersController(IUserService userService)
//        {
//            _userService = userService;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
//        {
//            var users = await _userService.GetUsers();
//            if (users == null || !users.Any())
//            {
//                return NotFound("Users not found");
//            }
//            return Ok(users);
//        }

//        [HttpGet("{id}", Name = "GetUser")]
//        public async Task<ActionResult<UserDTO>> Get(Guid id)
//        {
//            var user = await _userService.GetUserById(id);
//            if (user == null)
//            {
//                return NotFound("User not found");
//            }
//            return Ok(user);
//        }

//        [HttpPost]
//        public async Task<ActionResult> Post([FromBody] UserDTO userDto)
//        {
//            if (userDto == null)
//                return BadRequest("Invalid data");

//            await _userService.AddUser(userDto);

//            return new CreatedAtRouteResult("GetUser",
//                new { id = userDto.Id }, userDto);
//        }

//        [HttpPut("{id:guid}", Name = "UpdateUser")]
//        public async Task<ActionResult> Put(Guid id, [FromBody] UserDTO userDto)
//        {
//            if (id != userDto.Id)
//            {
//                return BadRequest("Invalid data");
//            }

//            if (userDto == null)
//                return BadRequest("Invalid data");

//            await _userService.UpdateUser(userDto);

//            return Ok(userDto);
//        }

//        [HttpDelete("{id:guid}", Name = "DeleteUser")]
//        public async Task<ActionResult<UserDTO>> Delete(Guid id)
//        {
//            var userDto = await _userService.GetUserById(id);

//            if (userDto == null)
//            {
//                return NotFound("User not found");
//            }

//            await _userService.RemoveUser(id);

//            return Ok(userDto);
//        }
//    }
//}