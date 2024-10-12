using AutoMapper;
using GwiNews.Application.DTOs;
using GwiNews.Application.Interfaces;
using GwiNews.Domain.Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task AddNewsCategory(NewsCategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<NewsCategory>(categoryDto);
            await _newsCategoryRepository.AddNewsCategory(categoryEntity);
        }

        public async Task<IEnumerable<NewsCategoryDTO>> GetNewsCategories()
        {
            var categoryEntities = await _newsCategoryRepository.GetAllNewsCategories();
            return _mapper.Map<IEnumerable<NewsCategoryDTO>>(categoryEntities);
        }

        public async Task<NewsCategoryDTO> GetNewsCategoryById(Guid? id)
        {
            var categoryEntity = await _newsCategoryRepository.GetNewsCategoryById(id);
            return _mapper.Map<NewsCategoryDTO>(categoryEntity);
        }

        public async Task RemoveNewsCategory(Guid? id)
        {
            var categoryEntity = await _newsCategoryRepository.GetNewsCategoryById(id);
            if (categoryEntity != null)
            {
                await _newsCategoryRepository.DeleteNewsCategory(categoryEntity.Id);
            }
        }

        public async Task UpdateNewsCategory(NewsCategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<NewsCategory>(categoryDto);
            await _newsCategoryRepository.UpdateNewsCategory(categoryEntity);
        }

        //public async Task<IEnumerable<NewsDTO>> GetNewsByCategory(Guid categoryId)
        //{
        //    var newsEntities = await _newsCategoryRepository.GetNewsByCategory(categoryId);
        //    return _mapper.Map<IEnumerable<NewsDTO>>(newsEntities);
        //}
    }
}
