using AutoMapper;
using GwiNews.Application.DTOs;
using GwiNews.Application.Interfaces;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;

namespace GwiNews.Application.Services
{
    public class NewsCategoryService : INewsCategoryService
    {
        private readonly INewsCategoryRepository _newsCategoryRepository;
        private readonly IMapper _mapper;

        public NewsCategoryService(INewsCategoryRepository newsCategoryRepository, IMapper mapper)
        {
            _newsCategoryRepository = newsCategoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NewsCategoryDTO>>? GetCategoriesAsync()
        {
            var categories = await _newsCategoryRepository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<NewsCategoryDTO>>(categories);
        }

        public async Task<NewsCategoryDTO>? GetCategoryByIdAsync(Guid? id)
        {
            var category = await _newsCategoryRepository.GetByIdAsync(id);
            return _mapper.Map<NewsCategoryDTO>(category);
        }

        public async Task<NewsCategoryDTO>? AddCategoryAsync(NewsCategoryDTO? categoryDto)
        {
            var categoryEntity = _mapper.Map<NewsCategory>(categoryDto);
            var createdCategory = await _newsCategoryRepository.CreateAsync(categoryEntity);
            return _mapper.Map<NewsCategoryDTO>(createdCategory);
        }

        public async Task<NewsCategoryDTO>? UpdateCategoryAsync(NewsCategoryDTO? categoryDto)
        {
            var categoryEntity = _mapper.Map<NewsCategory>(categoryDto);
            var updatedCategory = await _newsCategoryRepository.UpdateAsync(categoryEntity);
            return _mapper.Map<NewsCategoryDTO>(updatedCategory);
        }

        public async Task<NewsCategoryDTO>? RemoveCategoryAsync(Guid? id)
        {
            var categoryEntity = await _newsCategoryRepository.GetByIdAsync(id);
            if (categoryEntity != null)
            {
                var removedCategory = await _newsCategoryRepository.RemoveAsync(categoryEntity);
                return _mapper.Map<NewsCategoryDTO>(removedCategory);
            }

            return null;
        }

        public async Task<IEnumerable<NewsCategoryDTO>>? GetFilteredCategoriesAsync(string? name)
        {
            var categories = await _newsCategoryRepository.GetFilteredAsync(name);
            return _mapper.Map<IEnumerable<NewsCategoryDTO>>(categories);
        }
    }
}
