using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public interface IFormationRepository
    {
        Task<IEnumerable<Formation>>? GetFormationsAsync();
        Task<Formation>? GetByIdAsync(Guid? id);
        Task<Formation>? CreateAsync(Formation? formation);
        Task<Formation>? UpdateAsync(Formation? formation);
        Task<Formation>? RemoveAsync(Formation? formation);
        Task<IEnumerable<Formation>>? GetFilteredAsync(string? name, string? institution);
    }
}
