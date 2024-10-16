using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public interface IProfessionalSkillService
    {
        Task<IEnumerable<ProfessionalSkill>> GetAllProfessionalSkillsAsync();
        Task<ProfessionalSkill> GetProfessionalSkillByIdAsync(Guid id);
        Task<ProfessionalSkill> CreateProfessionalSkillAsync(ProfessionalSkill skill);
        Task<ProfessionalSkill> UpdateProfessionalSkillAsync(ProfessionalSkill skill);
        Task DeleteProfessionalSkillAsync(Guid id);
    }
}
