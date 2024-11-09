using AutoMapper;
using GwiNews.Application.DTOs;
using GwiNews.Application.Interfaces;
using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;

namespace GwiNews.Application.Services
{
    public class UserWithNewsService : UserService, IUserWithNewsService
    {
        private readonly IUserWithNewsRepository _userWithNewsRepository;
        private readonly IMapper _mapper;

        public UserWithNewsService(IUserWithNewsRepository userWithNewsRepository, IMapper mapper)
            : base(userWithNewsRepository, mapper)
        {
            _userWithNewsRepository = userWithNewsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NewsDTO>>? GetOwnNewsAsync(Guid? userWithNewsId)
        {
            var newsEntities = await _userWithNewsRepository.GetOwnNewsAsync(userWithNewsId);
            return _mapper.Map<IEnumerable<NewsDTO>>(newsEntities);
        }

        public async Task AddOwnNewsAsync(Guid? userWithNewsId, NewsDTO? newsDto)
        {
            if (newsDto == null) return;

            var newsEntity = _mapper.Map<News>(newsDto);
            await _userWithNewsRepository.AddOwnNewsAsync(userWithNewsId, newsEntity);
        }

        public async Task RemoveOwnNewsAsync(Guid? userWithNewsId, NewsDTO? newsDto)
        {
            if (newsDto == null) return;

            var newsEntity = _mapper.Map<News>(newsDto);
            await _userWithNewsRepository.RemoveOwnNewsAsync(userWithNewsId, newsEntity);
        }
    }
}
