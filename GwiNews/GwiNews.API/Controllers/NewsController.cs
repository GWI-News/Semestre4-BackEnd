using GwiNews.Application.DTOs;
using GwiNews.Application.Interfaces;
using GwiNews.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GwiNews.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsDTO>>> Get()
        {
            var news = await _newsService.GetNewsAsync();
            if (news == null || !news.Any())
            {
                return NotFound("No news found");
            }
            return Ok(news);
        }

        [HttpGet("{id:guid}", Name = "GetNews")]
        public async Task<ActionResult<NewsDTO>> Get(Guid id)
        {
            var news = await _newsService.GetNewsByIdAsync(id);
            if (news == null)
            {
                return NotFound("News not found");
            }
            return Ok(news);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] NewsDTO newsDto)
        {
            if (newsDto == null)
            {
                return BadRequest("Invalid data");
            }

            await _newsService.AddNewsAsync(newsDto);

            return CreatedAtRoute("GetNews",
                new { id = newsDto.Id }, newsDto);
        }

        [HttpPut("{id:guid}", Name = "UpdateNews")]
        public async Task<ActionResult> Put(Guid id, [FromBody] NewsDTO newsDto)
        {
            if (id != newsDto.Id)
            {
                return BadRequest("News ID mismatch");
            }

            if (newsDto == null)
            {
                return BadRequest("Invalid data");
            }

            await _newsService.UpdateNewsAsync(newsDto);

            return Ok(newsDto);
        }

        [HttpDelete("{id:guid}", Name = "DeleteNews")]
        public async Task<ActionResult<NewsDTO>> Delete(Guid id)
        {
            var news = await _newsService.GetNewsByIdAsync(id);

            if (news == null)
            {
                return NotFound("News not found");
            }

            await _newsService.RemoveNewsAsync(id);

            return Ok(news);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<NewsDTO>>> GetFiltered(
            [FromQuery] string? title,
            [FromQuery] NewsCategory? category,
            [FromQuery] NewsSubcategory? subcategory)
        {
            IEnumerable<NewsDTO>? news = null;

            if (!string.IsNullOrWhiteSpace(title))
            {
                news = await _newsService.GetFilteredNewsByTitleAsync(title);
            }
            else if (category != null)
            {
                news = await _newsService.GetFilteredNewsByCategoryAsync(category);
            }
            else if (subcategory != null)
            {
                news = await _newsService.GetFilteredNewsBySubcategoryAsync(subcategory);
            }

            if (news == null || !news.Any())
            {
                return NotFound("No news found with the specified filters");
            }

            return Ok(news);
        }
    }
}
