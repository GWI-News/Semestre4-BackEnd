using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GwiNews.Infra.Data.Repositories
{
    public class ProfessionalSkillRepository : IProfessionalSkillRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfessionalSkillRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtém todas as habilidades profissionais
        public async Task<IEnumerable<ProfessionalSkill>> GetAllAsync()
        {
            return await _context.ProfessionalSkills.ToListAsync();
        }

        // Obtém uma habilidade profissional específica pelo Id
        public async Task<ProfessionalSkill?> GetByIdAsync(Guid id)
        {
            return await _context.ProfessionalSkills.FindAsync(id);
        }

        // Cria uma nova habilidade profissional
        public async Task<ProfessionalSkill> CreateAsync(ProfessionalSkill professionalSkill)
        {
            _context.ProfessionalSkills.Add(professionalSkill);
            await _context.SaveChangesAsync();
            return professionalSkill;
        }

        // Atualiza uma habilidade profissional existente
        public async Task<ProfessionalSkill> UpdateAsync(ProfessionalSkill professionalSkill)
        {
            _context.ProfessionalSkills.Update(professionalSkill);
            await _context.SaveChangesAsync();
            return professionalSkill;
        }

        // Exclui uma habilidade profissional pelo Id
        public async Task DeleteAsync(Guid id)
        {
            var professionalSkill = await _context.ProfessionalSkills.FindAsync(id);
            if (professionalSkill != null)
            {
                _context.ProfessionalSkills.Remove(professionalSkill);
                await _context.SaveChangesAsync();
            }
        }
    }
}
