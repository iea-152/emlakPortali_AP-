using emlakPortali_APİ.Data;
using Microsoft.EntityFrameworkCore;
using emlakPortali_APİ.Data;
using emlakPortali_APİ.Models;

namespace Uyg.API.Repositories
{
    public class PropertyRepository
    {
        private readonly AppDbContext _context;

        public PropertyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Property>> GetAllAsync()
        {
            return await _context.Properties
                .Include(p => p.Category)
                .Include(p => p.Location)
                .ToListAsync();
        }

        public async Task<Property> GetByIdAsync(int id)
        {
            return await _context.Properties
                .Include(p => p.Category)
                .Include(p => p.Location)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Property property)
        {
            await _context.Properties.AddAsync(property);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Property property)
        {
            _context.Properties.Update(property);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var property = await GetByIdAsync(id);
            if (property != null)
            {
                _context.Properties.Remove(property);
                await _context.SaveChangesAsync();
            }
        }
    }
}