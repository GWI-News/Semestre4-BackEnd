using GwiNews.Domain.Entities;
using GwiNews.Domain.Interfaces;
using GwiNews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GwiNews.Infra.Data.Repositories
{
    public class FormationRepository : IFormationRepository
    {
        private readonly ApplicationDbContext _context;

        public FormationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Formation>>? GetFormationsAsync()
        {
            return await _context.Formations.ToListAsync();
        }

        public async Task<Formation>? GetByIdAsync(Guid? id)
        {
            return await _context.Formations.FindAsync(id);
        }

        public async Task<Formation>? CreateAsync(Formation? formation)
        {
            if (formation == null)
                return null;

            await _context.Formations.AddAsync(formation);
            await _context.SaveChangesAsync();
            return formation;
        }

        public async Task<Formation>? UpdateAsync(Formation? formation)
        {
            if (formation == null || formation.Id == null)
                return null;

            _context.Formations.Update(formation);
            await _context.SaveChangesAsync();
            return formation;
        }

        public async Task<Formation>? RemoveAsync(Formation? formation)
        {
            if (formation == null || formation.Id == null)
                return null;

            var existingFormation = await GetByIdAsync(formation.Id);
            if (existingFormation == null)
                return null;

            _context.Formations.Remove(existingFormation);
            await _context.SaveChangesAsync();
            return existingFormation;
        }

        public async Task<IEnumerable<Formation>>? GetFilteredAsync(string? name, string? institution)
        {
            var query = _context.Formations.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(f => f.Name != null && f.Name.Contains(name));
            }

            if (!string.IsNullOrWhiteSpace(institution))
            {
                query = query.Where(f => f.Institution != null && f.Institution.Contains(institution));
            }

            return await query.ToListAsync();
        }
    }
}
