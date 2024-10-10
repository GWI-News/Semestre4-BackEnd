using AutoMapper;
using GwiNews.Application.DTOs;
using GwiNews.Domain.Entities;

namespace GwiNews.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            // Mapeamento entre News e NewsDTO
            CreateMap<News, NewsDTO>().ReverseMap();

            // Mapeamento de propriedades associadas
            /*CreateMap<UserWithNews, UserWithNewsDTO>().ReverseMap();
            CreateMap<NewsCategory, NewsCategoryDTO>().ReverseMap();
            CreateMap<NewsSubcategory, NewsSubcategoryDTO>().ReverseMap();
            CreateMap<ReaderUser, ReaderUserDTO>().ReverseMap();*/
        }
    }
}
