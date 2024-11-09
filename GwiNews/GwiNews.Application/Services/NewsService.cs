using AutoMapper;
using GwiNews.Application.DTOs;
using GwiNews.Application.Interfaces;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;

namespace GwiNews.Application.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;

        public NewsService(INewsRepository newsRepository, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NewsDTO>>? GetNewsAsync()
        {
            var newsEntities = await _newsRepository.GetNewsAsync();
            return _mapper.Map<IEnumerable<NewsDTO>>(newsEntities);
        }

        public async Task<NewsDTO>? GetNewsByIdAsync(Guid? id)
        {
            var newsEntity = await _newsRepository.GetByIdAsync(id);
            return _mapper.Map<NewsDTO>(newsEntity);
        }

        public async Task AddNewsAsync(NewsDTO? newsDto)
        {
            var newsEntity = _mapper.Map<News>(newsDto);
            await _newsRepository.CreateAsync(newsEntity);
        }

        public async Task UpdateNewsAsync(NewsDTO? newsDto)
        {
            var newsEntity = _mapper.Map<News>(newsDto);
            await _newsRepository.UpdateAsync(newsEntity);
        }

        public async Task RemoveNewsAsync(Guid? id)
        {
            var newsEntity = await _newsRepository.GetByIdAsync(id);
            if (newsEntity != null)
            {
                await _newsRepository.RemoveAsync(newsEntity);
            }
        }

        public async Task<IEnumerable<NewsDTO>>? GetFilteredNewsByTitleAsync(string? title)
        {
            var newsEntities = await _newsRepository.GetFilteredByTitleAsync(title);
            return _mapper.Map<IEnumerable<NewsDTO>>(newsEntities);
        }

        public async Task<IEnumerable<NewsDTO>>? GetFilteredNewsByCategoryAsync(NewsCategory? category)
        {
            var newsEntities = await _newsRepository.GetFilteredByCatgoryAsync(category);
            return _mapper.Map<IEnumerable<NewsDTO>>(newsEntities);
        }

        public async Task<IEnumerable<NewsDTO>>? GetFilteredNewsBySubcategoryAsync(NewsSubcategory? subcategory)
        {
            var newsEntities = await _newsRepository.GetFilteredBySubcategoryAsync(subcategory);
            return _mapper.Map<IEnumerable<NewsDTO>>(newsEntities);
        }
    }
}
