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
        public async Task<IEnumerable<NewsDTO>> GetNews()
        {
            var newsEntity = await _newsRepository.GetAllNewsAsync();
            return _mapper.Map<IEnumerable<NewsDTO>>(newsEntity);
        }

        public async Task<NewsDTO> GetNewsById(Guid? id)
        {
            var newsEntity = await _newsRepository.GetNewsByIdAsync(id);
            return _mapper.Map<NewsDTO>(newsEntity);
        }
        public async Task AddNews(NewsDTO newsDto)
        {
            var newsEntity = _mapper.Map<News>(newsDto);
            await _newsRepository.AddNewsAsync(newsEntity);
        }

        public async Task RemoveNews(Guid? id)
        {
            var newsEntity = await _newsRepository.GetNewsByIdAsync(id);
            await _newsRepository.DeleteNewsAsync(newsEntity.Id);
        }

        public async Task UpdateNews(NewsDTO newsDto)
        {
            var newsEntity = _mapper.Map<News>(newsDto);
            await _newsRepository.UpdateNewsAsync(newsEntity);
        }

        /*public async Task<IEnumerable<NewsDTO>> GetNewsByStatus(NewsStatus status)
        {
            var newsEntities = await _newsRepository.GetNewsByStatus(status);
            return _mapper.Map<IEnumerable<NewsDTO>>(newsEntities);
        }

        public async Task<IEnumerable<NewsDTO>> GetNewsByCategory(Guid categoryId)
        {
            var newsEntities = await _newsRepository.GetNewsByCategory(categoryId);
            return _mapper.Map<IEnumerable<NewsDTO>>(newsEntities);
        }

        public async Task<IEnumerable<ReaderUserDTO>> GetFavoritedByUsers(Guid newsId)
        {
            var usersEntities = await _newsRepository.GetFavoritedByUsers(newsId);
            return _mapper.Map<IEnumerable<ReaderUserDTO>>(usersEntities);
        } */
    }
}
