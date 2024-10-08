using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;
using GwiNews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GwiNews.Infra.Data.Repositories
{
    public class FormationRepository : IFormationRepository
    {
        private readonly ApplicationDbContext _context;

        public FormationRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Formation>> GetAllAsync()
        {
            return await _context.Formations.ToListAsync();
        }

        public async Task<Formation> GetByIdAsync(Guid id)
        {
            return await _context.Formations.FindAsync(id);
        }

        public async Task<Formation> CreateAsync(Formation formation)
        {
            await _context.Formations.AddAsync(formation);
            await _context.SaveChangesAsync();
            return formation;
        }

        public async Task<Formation> UpdateAsync(Formation formation)
        {
            _context.Formations.Update(formation);
            await _context.SaveChangesAsync();
            return formation;
        }

        public async Task DeleteAsync(Guid id)
        {
            var formation = await _context.Formations.FindAsync(id);
            if (formation != null)
            {
                _context.Formations.Remove(formation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
