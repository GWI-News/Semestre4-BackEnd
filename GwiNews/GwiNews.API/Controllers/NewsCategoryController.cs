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
            var categories = await _newsCategoryService.GetCategoriesAsync();
            if (categories == null || !categories.Any())
            {
                return NotFound("Categories not found");
            }
            return Ok(categories);
        }

        [HttpGet("{id:guid}", Name = "GetNewsCategory")]
        public async Task<ActionResult<NewsCategoryDTO>> Get(Guid id)
        {
            var category = await _newsCategoryService.GetCategoryByIdAsync(id);
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

            var createdCategory = await _newsCategoryService.AddCategoryAsync(categoryDto);

            return CreatedAtRoute("GetNewsCategory",
                new { id = createdCategory.Id }, createdCategory);
        }

        [HttpPut("{id:guid}", Name = "UpdateNewsCategory")]
        public async Task<ActionResult> Put(Guid id, [FromBody] NewsCategoryDTO categoryDto)
        {
            if (id != categoryDto.Id)
            {
                return BadRequest("Category ID mismatch");
            }

            if (categoryDto == null)
                return BadRequest("Invalid data");

            var updatedCategory = await _newsCategoryService.UpdateCategoryAsync(categoryDto);
            return Ok(updatedCategory);
        }

        [HttpDelete("{id:guid}", Name = "DeleteNewsCategory")]
        public async Task<ActionResult<NewsCategoryDTO>> Delete(Guid id)
        {
            var category = await _newsCategoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound("Category not found");
            }

            var removedCategory = await _newsCategoryService.RemoveCategoryAsync(id);
            return Ok(removedCategory);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<NewsCategoryDTO>>> GetFiltered([FromQuery] string? name)
        {
            var categories = await _newsCategoryService.GetFilteredCategoriesAsync(name);
            if (categories == null || !categories.Any())
            {
                return NotFound("No categories found with the specified filter");
            }
            return Ok(categories);
        }
    }
}
