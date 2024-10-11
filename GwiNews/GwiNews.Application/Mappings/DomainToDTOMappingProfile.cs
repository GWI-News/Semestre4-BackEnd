using AutoMapper;
using GwiNews.Application.DTOs;
using GwiNews.Domain.Entities;

namespace Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<News, NewsDTO>().ReverseMap();
            CreateMap<NewsCategory, NewsCategoryDTO>().ReverseMap();
        }
    }
}
