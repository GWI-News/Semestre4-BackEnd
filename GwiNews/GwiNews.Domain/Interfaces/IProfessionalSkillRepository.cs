using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public interface IProfessionalSkillRepository
    {
        Task<IEnumerable<ProfessionalSkill>> GetAllAsync();
        Task<ProfessionalSkill?> GetByIdAsync(Guid? id);
        Task<ProfessionalSkill> CreateAsync(ProfessionalSkill skill);
        Task<ProfessionalSkill> UpdateAsync(ProfessionalSkill skill);
        Task DeleteAsync(Guid? id);
    }
}
