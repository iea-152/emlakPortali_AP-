using emlakPortali_APİ.Data;
using emlakPortali_APİ.Models;
using Microsoft.EntityFrameworkCore;

namespace emlakPortali_APİ.Repositories
{
    public class LocationRepository
    {
        private readonly AppDbContext _context;

        public AppDbContext Context => _context;

        public LocationRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<City>> GetCitiesAsync()
        {
            return await _context.Cities.OrderBy(x => x.Name).ToListAsync();
        }
        public async Task<List<District>> GetDistrictsByCityIdAsync(int cityId)
        {
            return await _context.Districts
                .Where(x => x.CityId == cityId)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
    }
}