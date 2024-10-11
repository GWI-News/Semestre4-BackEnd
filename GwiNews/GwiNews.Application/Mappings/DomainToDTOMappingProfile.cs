using AutoMapper;
using GwiNews.Application.DTOs;
using GwiNews.Domain.Entities;

namespace GwiNews.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<GwiNews.Domain.Entities.News, NewsDTO>().ReverseMap();
            CreateMap<NewsCategory, NewsCategoryDTO>().ReverseMap();
        }
    }
}
