using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public interface IProfessionalInformationRepository
    {
        Task<ProfessionalInformation> GetByIdAsync(Guid id);
        Task<ProfessionalInformation> CreateAsync(ProfessionalInformation information);
        Task<ProfessionalInformation> UpdateAsync(ProfessionalInformation information);
        Task DeleteAsync(Guid id);
    }
}
