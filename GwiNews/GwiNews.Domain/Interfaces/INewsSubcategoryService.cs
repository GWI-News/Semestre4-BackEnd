using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public class INewsSubcategoryService
    {
        // Método para obter todas as subcategorias de notícias
        Task<IEnumerable<NewsSubcategory>> GetAllNewsSubcategoriesAsync();

        // Método para obter uma subcategoria de notícia específica pelo Id
        Task<NewsSubcategory> GetNewsSubcategoryByIdAsync(Guid id);

        // Método para criar uma nova subcategoria de notícia
        Task<NewsSubcategory> CreateNewsSubcategoryAsync(NewsSubcategory newsSubcategory);

        // Método para atualizar uma subcategoria de notícia existente
        Task<NewsSubcategory> UpdateNewsSubcategoryAsync(NewsSubcategory newsSubcategory);

        // Método para excluir uma subcategoria de notícia pelo Id
        Task DeleteNewsSubcategoryAsync(Guid id);
    }
}
