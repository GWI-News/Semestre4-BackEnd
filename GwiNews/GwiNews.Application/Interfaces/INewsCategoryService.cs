using GwiNews.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwiNews.Application.Interfaces
{

    public interface INewsCategoryService
    {
        Task<IEnumerable<NewsCategoryDTO>> GetNewsCategories();

        Task<NewsCategoryDTO> GetNewsCategoryById(Guid id);

        Task AddNewsCategory(NewsCategoryDTO categoryDto);

        Task UpdateNewsCategory(NewsCategoryDTO categoryDto);

        Task RemoveNewsCategory(Guid id);

        //Task<IEnumerable<NewsDTO>> GetNewsByCategory(Guid categoryId);

        //Task<IEnumerable<NewsSubcategoryDTO>> GetNewsSubcategoriesByCategory(Guid categoryId);
    }
}
