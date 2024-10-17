using GwiNews.Domain.Entities;

namespace GwiNews.Domain.Interfaces
{
    public interface IReaderUserRepository : IUserRepository
    {
        Task<IEnumerable<News>>? GetFavoritedNewsAsync(Guid? readerUserId);
        Task AddFavoritedNewsAsync(Guid? readerUserId, News? news);
        Task RemoveFavoritedNewsAsync(Guid? readerUserId, News? news);
        Task<IEnumerable<ProfessionalInformation>>? GetProfessionalInformationsAsync(Guid? readerUserId);
        Task AddProfessionalInformationAsync(Guid? readerUserId, ProfessionalInformation? professionalInformation);
        Task RemoveProfessionalInformationAsync(Guid? readerUserId, ProfessionalInformation? professionalInformation);
        Task<IEnumerable<Formation>>? GetFormationsAsync(Guid? readerUserId);
        Task AddFormationAsync(Guid? readerUserId, Formation? formation);
        Task RemoveFormationAsync(Guid? readerUserId, Formation? formation);
        Task<IEnumerable<ProfessionalSkill>>? GetProfessionalSkillsAsync(Guid? readerUserId);
        Task AddProfessionalSkillAsync(Guid? readerUserId, ProfessionalSkill? professionalSkill);
        Task RemoveProfessionalSkillAsync(Guid? readerUserId, ProfessionalSkill? professionalSkill);
    }
}
