using GwiNews.Application.DTOs;
using GwiNews.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GwiNews.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsCategoryController : ControllerBase
    {
        private readonly INewsCategoryService _newsCategoryService;

        public NewsCategoryController(INewsCategoryService newsCategoryService)
        {
            _newsCategoryService = newsCategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsCategoryDTO>>> Get()
        {
            var categoriesList = await _newsCategoryService.GetNewsCategories();
            if (categoriesList == null || !categoriesList.Any())
            {
                return NotFound("No categories found");
            }
            return Ok(categoriesList);
        }

        [HttpGet("{id}", Name = "GetNewsCategory")]
        public async Task<ActionResult<NewsCategoryDTO>> Get(Guid id)
        {
            var category = await _newsCategoryService.GetNewsCategoryById(id);
            if (category == null)
            {
                return NotFound("Category not found");
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] NewsCategoryDTO categoryDto)
        {
            if (categoryDto == null)
                return BadRequest("Invalid data");

            await _newsCategoryService.AddNewsCategory(categoryDto);

            return new CreatedAtRouteResult("GetNewsCategory",
                new { id = categoryDto.Id }, categoryDto);
        }

        [HttpPut("{id:guid}", Name = "UpdateNewsCategory")]
        public async Task<ActionResult> Put(Guid id, [FromBody] NewsCategoryDTO categoryDto)
        {
            if (id != categoryDto.Id)
            {
                return BadRequest("Invalid data");
            }

            if (categoryDto == null)
                return BadRequest("Invalid data");

            await _newsCategoryService.UpdateNewsCategory(categoryDto);

            return Ok(categoryDto);
        }

        [HttpDelete("{id:guid}", Name = "DeleteNewsCategory")]
        public async Task<ActionResult<NewsCategoryDTO>> Delete(Guid id)
        {
            var categoryDto = await _newsCategoryService.GetNewsCategoryById(id);

            if (categoryDto == null)
            {
                return NotFound("Category not found");
            }

            await _newsCategoryService.RemoveNewsCategory(id);

            return Ok(categoryDto);
        }
    }
}
