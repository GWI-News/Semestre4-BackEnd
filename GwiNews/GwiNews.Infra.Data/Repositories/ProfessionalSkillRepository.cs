using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GwiNews.Infra.Data.Repositories
{
    public class ProfessionalSkillRepository : IProfessionalSkillRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfessionalSkillRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProfessionalSkill>> GetAllAsync()
        {
            return await _context.ProfessionalSkills.ToListAsync();
        }

        public async Task<ProfessionalSkill?> GetByIdAsync(Guid? id)
        {
            return await _context.ProfessionalSkills.FindAsync(id);
        }

        public async Task<ProfessionalSkill> CreateAsync(ProfessionalSkill skill)
        {
            if (skill == null)
                throw new ArgumentNullException(nameof(skill));

            await _context.ProfessionalSkills.AddAsync(skill);
            await _context.SaveChangesAsync();
            return skill;
        }

        public async Task<ProfessionalSkill> UpdateAsync(ProfessionalSkill skill)
        {
            if (skill == null || skill.Id == null)
                throw new ArgumentNullException(nameof(skill));

            _context.ProfessionalSkills.Update(skill);
            await _context.SaveChangesAsync();
            return skill;
        }

        public async Task DeleteAsync(Guid? id)
        {
            var skill = await GetByIdAsync(id);
            if (skill == null)
                throw new KeyNotFoundException("Habilidade não encontrada.");

            _context.ProfessionalSkills.Remove(skill);
            await _context.SaveChangesAsync();
        }
    }
}
