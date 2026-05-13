using emlakPortali_APİ.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace emlakPortali_APİ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LocationController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("Cities")]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _context.Cities
                .Select(c => new { c.Id, c.Name })
                .ToListAsync();

            return Ok(cities);
        }

        [HttpGet("Districts/{cityId}")]
        public async Task<IActionResult> GetDistricts(int cityId)
        {
            var districts = await _context.Districts
                .Where(d => d.CityId == cityId)
                .Select(d => new { d.Id, d.Name })
                .ToListAsync();

            if (!districts.Any()) return NotFound(new { Message = "Bu şehre ait ilçe bulunamadı." });

            return Ok(districts);
        }
        [HttpGet("Neighborhoods/{districtId}")]
        public async Task<IActionResult> GetNeighborhoods(int districtId)
        {
            var neighborhoods = await _context.Neighborhoods
                .Where(n => n.DistrictId == districtId)
                .Select(n => new { n.Id, n.Name })
                .ToListAsync();

            if (!neighborhoods.Any()) return NotFound(new { Message = "Bu ilçeye ait mahalle bulunamadı." });

            return Ok(neighborhoods);
        }
    }
}