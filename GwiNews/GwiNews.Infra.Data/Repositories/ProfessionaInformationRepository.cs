using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GwiNews.Infra.Data.Repositories
{
    public class ProfessionalInformationRepository : IProfessionalInformationRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfessionalInformationRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ProfessionalInformation> CreateAsync(ProfessionalInformation information)
        {
            await _context.ProfessionalInformation.AddAsync(information);
            await _context.SaveChangesAsync();
            return information;
        }

        public async Task DeleteAsync(Guid id)
        {
            var information = await GetByIdAsync(id);
            if (information != null)
            {
                _context.ProfessionalInformation.Remove(information);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProfessionalInformation>> GetAllAsync()
        {
            return await _context.ProfessionalInformation.ToListAsync();
        }

        public async Task<ProfessionalInformation> GetByIdAsync(Guid id)
        {
            return await _context.ProfessionalInformation.FindAsync(id);
        }

        public async Task<ProfessionalInformation> UpdateAsync(ProfessionalInformation information)
        {
            _context.ProfessionalInformation.Update(information);
            await _context.SaveChangesAsync();
            return information;
        }
    }
}
