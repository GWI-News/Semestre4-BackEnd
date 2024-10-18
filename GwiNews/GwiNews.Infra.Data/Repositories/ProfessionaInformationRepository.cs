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
            _context = context;
        }

        public async Task<IEnumerable<ProfessionalInformation>>? GetAllAsync()
        {
            return await _context.ProfessionalInformations.ToListAsync();
        }

        public async Task<ProfessionalInformation>? GetByIdAsync(Guid? id)
        {
            if (id == null)
                return null;

            return await _context.ProfessionalInformations.FindAsync(id);
        }

        public async Task<ProfessionalInformation>? CreateAsync(ProfessionalInformation? professionalInformation)
        {
            if (professionalInformation == null)
                return null;

            await _context.ProfessionalInformations.AddAsync(professionalInformation);
            await _context.SaveChangesAsync();
            return professionalInformation;
        }

        public async Task<ProfessionalInformation>? UpdateAsync(ProfessionalInformation? professionalInformation)
        {
            if (professionalInformation == null || professionalInformation.Id == null)
                return null;

            _context.ProfessionalInformations.Update(professionalInformation);
            await _context.SaveChangesAsync();
            return professionalInformation;
        }

        public async Task<ProfessionalInformation>? RemoveAsync(ProfessionalInformation? professionalInformation)
        {
            if (professionalInformation == null || professionalInformation.Id == null)
                return null;

            var existingInfo = await GetByIdAsync(professionalInformation.Id);
            if (existingInfo == null)
                return null;

            _context.ProfessionalInformations.Remove(existingInfo);
            await _context.SaveChangesAsync();
            return existingInfo;
        }
    }
}
