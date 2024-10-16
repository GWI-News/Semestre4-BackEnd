using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public interface IFormationService
    {
        Task<IEnumerable<Formation>> GetAllFormationsAsync();
        Task<Formation> GetFormationByIdAsync(Guid id);
        Task<Formation> CreateFormationAsync(Formation formation);
        Task<Formation> UpdateFormationAsync(Formation formation);
        Task DeleteFormationAsync(Guid id);
    }
}
