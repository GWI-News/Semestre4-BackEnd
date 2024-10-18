using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;

namespace GwiNews.Infra.Data.Repositories
{
    public class ReaderUserRepository : UserRepository, IReaderUserRepository
    {
        private readonly ApplicationDbContext _context;

        public ReaderUserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<News>>? GetFavoritedNewsAsync(Guid? readerUserId)
        {
            var readerUser = await GetByIdAsync(readerUserId) as ReaderUser;
            return readerUser?.FavoritedNews?.ToList();
        }

        public async Task AddFavoritedNewsAsync(Guid? readerUserId, News? news)
        {
            var readerUser = await GetByIdAsync(readerUserId) as ReaderUser;
            if (readerUser != null && news != null)
            {
                readerUser.FavoritedNews?.Add(news);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveFavoritedNewsAsync(Guid? readerUserId, News? news)
        {
            var readerUser = await GetByIdAsync(readerUserId) as ReaderUser;
            if (readerUser != null && news != null && readerUser.FavoritedNews?.Contains(news) == true)
            {
                readerUser.FavoritedNews?.Remove(news);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProfessionalInformation>>? GetProfessionalInformationsAsync(Guid? readerUserId)
        {
            var readerUser = await GetByIdAsync(readerUserId) as ReaderUser;
            return readerUser?.ProfessionalInformations?.ToList();
        }

        public async Task AddProfessionalInformationAsync(Guid? readerUserId, ProfessionalInformation? professionalInformation)
        {
            var readerUser = await GetByIdAsync(readerUserId) as ReaderUser;
            if (readerUser != null && professionalInformation != null)
            {
                readerUser.ProfessionalInformations?.Add(professionalInformation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveProfessionalInformationAsync(Guid? readerUserId, ProfessionalInformation? professionalInformation)
        {
            var readerUser = await GetByIdAsync(readerUserId) as ReaderUser;
            if (readerUser != null && professionalInformation != null && readerUser.ProfessionalInformations?.Contains(professionalInformation) == true)
            {
                readerUser.ProfessionalInformations?.Remove(professionalInformation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Formation>>? GetFormationsAsync(Guid? readerUserId)
        {
            var readerUser = await GetByIdAsync(readerUserId) as ReaderUser;
            return readerUser?.Formations?.ToList();
        }

        public async Task AddFormationAsync(Guid? readerUserId, Formation? formation)
        {
            var readerUser = await GetByIdAsync(readerUserId) as ReaderUser;
            if (readerUser != null && formation != null)
            {
                readerUser.Formations?.Add(formation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveFormationAsync(Guid? readerUserId, Formation? formation)
        {
            var readerUser = await GetByIdAsync(readerUserId) as ReaderUser;
            if (readerUser != null && formation != null && readerUser.Formations?.Contains(formation) == true)
            {
                readerUser.Formations?.Remove(formation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProfessionalSkill>>? GetProfessionalSkillsAsync(Guid? readerUserId)
        {
            var readerUser = await GetByIdAsync(readerUserId) as ReaderUser;
            return readerUser?.ProfessionalSkills?.ToList();
        }

        public async Task AddProfessionalSkillAsync(Guid? readerUserId, ProfessionalSkill? professionalSkill)
        {
            var readerUser = await GetByIdAsync(readerUserId) as ReaderUser;
            if (readerUser != null && professionalSkill != null)
            {
                readerUser.ProfessionalSkills?.Add(professionalSkill);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveProfessionalSkillAsync(Guid? readerUserId, ProfessionalSkill? professionalSkill)
        {
            var readerUser = await GetByIdAsync(readerUserId) as ReaderUser;
            if (readerUser != null && professionalSkill != null && readerUser.ProfessionalSkills?.Contains(professionalSkill) == true)
            {
                readerUser.ProfessionalSkills?.Remove(professionalSkill);
                await _context.SaveChangesAsync();
            }
        }
    }
}
