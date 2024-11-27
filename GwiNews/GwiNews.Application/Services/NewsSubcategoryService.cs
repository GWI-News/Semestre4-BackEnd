using GwiNews.Application.Interfaces;
using GwiNews.Application.DTOs;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;

namespace GwiNews.Application.Services
{
        public class NewsSubcategoryService : INewsSubcategoryService
        {
            private readonly INewsSubcategoryRepository _newsSubcategoryRepository;
            private readonly IMapper _mapper;

            public NewsSubcategoryService(INewsSubcategoryRepository newsSubcategoryRepository, IMapper mapper)
            {
                _newsSubcategoryRepository = newsSubcategoryRepository;
                _mapper = mapper;
            }

            public async Task AddNewsSubcategory(NewsSubcategoryDTO subcategoryDto)
            {
                var subcategoryEntity = _mapper.Map<NewsSubcategory>(subcategoryDto);
                await _newsSubcategoryRepository.AddNewsSubcategory(subcategoryEntity);
            }

            public async Task<IEnumerable<NewsSubcategoryDTO>> GetNewsSubcategories()
            {
                var subcategoryEntities = await _newsSubcategoryRepository.GetAllNewsSubcategories();
                return _mapper.Map<IEnumerable<NewsSubcategoryDTO>>(subcategoryEntities);
            }

            public async Task<NewsSubcategoryDTO> GetNewsSubcategoryById(Guid id)
            {
                var subcategoryEntity = await _newsSubcategoryRepository.GetNewsSubcategoryById(id);
                return _mapper.Map<NewsSubcategoryDTO>(subcategoryEntity);
            }

            public async Task RemoveNewsSubcategory(Guid id)
            {
                var subcategoryEntity = await _newsSubcategoryRepository.GetNewsSubcategoryById(id);
                await _newsSubcategoryRepository.DeleteNewsSubcategory(subcategoryEntity.Id);
            }

            public async Task UpdateNewsSubcategory(NewsSubcategoryDTO subcategoryDto)
            {
                var subcategoryEntity = _mapper.Map<NewsSubcategory>(subcategoryDto);
                await _newsSubcategoryRepository.UpdateNewsSubcategory(subcategoryEntity);
            }

            public async Task<IEnumerable<NewsDTO>> GetNewsBySubcategory(Guid subcategoryId)
            {
                var newsEntities = await _newsSubcategoryRepository.GetNewsBySubcategory(subcategoryId);
                return _mapper.Map<IEnumerable<NewsDTO>>(newsEntities);
            }

            public async Task<NewsCategoryDTO> GetNewsCategoryBySubcategory(Guid subcategoryId)
            {
                var categoryEntity = await _newsSubcategoryRepository.GetNewsCategoryBySubcategory(subcategoryId);
                return _mapper.Map<NewsCategoryDTO>(categoryEntity);
            }
        }
}
