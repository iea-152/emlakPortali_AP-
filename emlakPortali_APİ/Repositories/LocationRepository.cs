using emlakPortali_APİ.Data;
using emlakPortali_APİ.Models;
using Microsoft.EntityFrameworkCore;
using emlakPortali_APİ.Data;
using emlakPortali_APİ.Models;

namespace emlakPortali_APİ.Repositories
{
    public class LocationRepository
    {
        private readonly AppDbContext _context;

        public LocationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Location>> GetListAsync()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<Location> GetByIdAsync(int id)
        {
            return await _context.Locations.FindAsync(id);
        }
    }
}