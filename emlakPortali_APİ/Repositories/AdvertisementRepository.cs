using Microsoft.EntityFrameworkCore;
using emlakPortali_APİ.Data;
using emlakPortali_APİ.DTOs;
using emlakPortali_APİ.Models;
using Microsoft.EntityFrameworkCore;

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
                .Include(a => a.City)
                .Include(a => a.Images)
                .ToListAsync();
        }

        public async Task<Advertisement> GetByIdAsync(int id)
        {
            return await _context.Advertisements
                .Include(a => a.Category)
                .Include(a => a.City)
                .Include(a => a.District)
                .Include(a => a.NeighborhoodName)
                .Include(a => a.Images)
                .Include(a => a.Features) 
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
        public async Task<List<Advertisement>> GetApprovedAsync()
        {
            return await _context.Advertisements
                .Include(a => a.Category)
                .Include(a => a.City)
                .Include(a => a.Images)
                .Where(a => a.IsApproved == true && a.IsActive == true) // Sadece onaylılar!
                .ToListAsync();
        }

        public async Task ApproveAsync(int id)
        {
            var advertisement = await _context.Advertisements.FindAsync(id);
            if (advertisement != null)
            {
                advertisement.IsApproved = true; // Onay verildi!
                await _context.SaveChangesAsync();
            }
    }
        public async Task<List<Advertisement>> GetFilteredAsync(AdvertisementFilterDto filter)
        {
            var query = _context.Advertisements
                .Include(a => a.Category)
                .Include(a => a.City)
                .Include(a => a.Images)
                .Where(a => a.IsApproved == true && a.IsActive == true)
                .AsQueryable();
            if (filter.CityId.HasValue && filter.CityId > 0)
                query = query.Where(a => a.CityId == filter.CityId.Value);

            if (filter.DistrictId.HasValue && filter.DistrictId > 0)
                query = query.Where(a => a.DistrictId == filter.DistrictId.Value);

            if (filter.CategoryId.HasValue && filter.CategoryId > 0)
                query = query.Where(a => a.CategoryId == filter.CategoryId.Value);

            if (filter.MinPrice.HasValue)
                query = query.Where(a => a.Price >= filter.MinPrice.Value);

            if (filter.MaxPrice.HasValue)
                query = query.Where(a => a.Price <= filter.MaxPrice.Value);

            if (!string.IsNullOrEmpty(filter.RoomCount))
                query = query.Where(a => a.RoomCount == filter.RoomCount);

            return await query.ToListAsync();
        }
    }

}