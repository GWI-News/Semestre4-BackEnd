using GwiNews.Application.DTOs;
using GwiNews.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GwiNews.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWithNewsController : ControllerBase
    {
        private readonly IUserWithNewsService _userWithNewsService;

        public UserWithNewsController(IUserWithNewsService userWithNewsService)
        {
            _userWithNewsService = userWithNewsService;
        }

        [HttpGet("{id:guid}/news", Name = "GetUserOwnNews")]
        public async Task<ActionResult<IEnumerable<NewsDTO>>> GetOwnNews(Guid id)
        {
            var news = await _userWithNewsService.GetOwnNewsAsync(id);
            if (news == null || !news.Any())
            {
                return NotFound("No news found for the user.");
            }
            return Ok(news);
        }

        [HttpPost("{id:guid}/news", Name = "AddUserOwnNews")]
        public async Task<ActionResult> AddOwnNews(Guid id, [FromBody] NewsDTO newsDto)
        {
            if (newsDto == null)
                return BadRequest("Invalid news data.");

            await _userWithNewsService.AddOwnNewsAsync(id, newsDto);

            return CreatedAtRoute("GetUserOwnNews", new { id }, newsDto);
        }

        [HttpDelete("{id:guid}/news", Name = "RemoveUserOwnNews")]
        public async Task<ActionResult> RemoveOwnNews(Guid id, [FromBody] NewsDTO newsDto)
        {
            if (newsDto == null)
                return BadRequest("Invalid news data.");

            await _userWithNewsService.RemoveOwnNewsAsync(id, newsDto);

            return Ok($"News removed from user {id}.");
        }
    }
}
