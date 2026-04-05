using Microsoft.EntityFrameworkCore;
using emlakPortali_APİ.Data;
using emlakPortali_APİ.Models;

namespace emlakPortali_APİ.Repositories
{
    public class AdvertisementRepository
    {
        private readonly AppDbContext _context;

        public AdvertisementRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Advertisement>> GetAllAsync()
        {
            return await _context.Advertisements
                .Include(a => a.Category)
                .Include(a => a.Images)
                .ToListAsync();
        }

        public async Task<Advertisement> GetByIdAsync(int id)
        {
            return await _context.Advertisements
                .Include(a => a.Category)
                .Include(a => a.Images)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAsync(Advertisement advertisement)
        {
            await _context.Advertisements.AddAsync(advertisement);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Advertisement advertisement)
        {
            _context.Advertisements.Update(advertisement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var advertisement = await GetByIdAsync(id);
            if (advertisement != null)
            {
                _context.Advertisements.Remove(advertisement);
                await _context.SaveChangesAsync();
            }
        }
    }
}