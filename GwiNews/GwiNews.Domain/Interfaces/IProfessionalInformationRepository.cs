using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public interface IProfessionalInformationRepository
    {
        Task<IEnumerable<ProfessionalInformation>>? GetAllAsync();
        Task<ProfessionalInformation>? GetByIdAsync(Guid? id);
        Task<ProfessionalInformation>? CreateAsync(ProfessionalInformation? professionalInformation);
        Task<ProfessionalInformation>? UpdateAsync(ProfessionalInformation? professionalInformation);
        Task<ProfessionalInformation>? RemoveAsync(ProfessionalInformation? professionalInformation);
    }
}
