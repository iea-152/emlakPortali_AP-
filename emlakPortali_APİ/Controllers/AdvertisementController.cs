using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using emlakPortali_APİ.Models;
using emlakPortali_APİ.Repositories;
using emlakPortali_APİ.DTOs;
using System.Security.Claims;

namespace emlakPortali_APİ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly AdvertisementRepository _repository;

        public AdvertisementController(AdvertisementRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _repository.GetAllAsync();
            return Ok(values);
        }

            var dtoList = values.Select(a => new AdvertisementListDto
            {
                Id = a.Id,
                Title = a.Title,
                Price = a.Price,
                RoomCount = a.RoomCount,
                CityName = a.City != null ? a.City.Name : "Belirtilmemiş",
                CategoryName = a.Category != null ? a.Category.Name : "Belirtilmemiş",
                CreatedDate = a.CreatedDate
            }).ToList();

            return Ok(dtoList);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var a = await _repository.GetByIdAsync(id);

            if (a == null) return NotFound(new { Message = "İlan bulunamadı!" });

            var detailDto = new AdvertisementDetailDto
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                Price = a.Price,
                SquareMeter = a.SquareMeter,
                RoomCount = a.RoomCount,
                BuildingAge = a.BuildingAge,
                FloorNumber = a.FloorNumber,
                HeatingType = a.HeatingType,
                IsFurnished = a.IsFurnished,
                TasinmazNo = a.TasinmazNo,
                CityName = a.City?.Name ?? "Belirtilmemiş",
                DistrictName = a.District?.Name ?? "Belirtilmemiş",
                NeighborhoodName = a.NeighborhoodName ?? "Belirtilmemiş",
                CategoryName = a.Category?.Name ?? "Belirtilmemiş",
                SellerFullName = a.AppUser != null ? $"{a.AppUser.FirstName} {a.AppUser.LastName}" : "Bilinmeyen Satıcı",
                CreatedDate = a.CreatedDate,
                ImageUrls = a.Images?.Select(i => i.ImageUrl).ToList() ?? new List<string>(),
                Features = a.Features?.Select(f => f.Name).ToList() ?? new List<string>()
            };

            return Ok(detailDto);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AdvertisementCreateDto dto)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier && Guid.TryParse(c.Value, out _))?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new { Message = "Güvenlik hatası: Geçersiz token veya ID bulunamadı!" });

            var newAd = new Advertisement
        {
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                SquareMeter = dto.SquareMeter,
                RoomCount = dto.RoomCount,
                BuildingAge = dto.BuildingAge,
                FloorNumber = dto.FloorNumber,
                HeatingType = dto.HeatingType,
                IsFurnished = dto.IsFurnished,
                TasinmazNo = dto.TasinmazNo,
                CityId = dto.CityId,
                DistrictId = dto.DistrictId,
                NeighborhoodName = dto.NeighborhoodName,
                CategoryId = dto.CategoryId,
                AppUserId = userId,
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsApproved = false,
                EIDSVerified = false
            };

            await _repository.AddAsync(newAd);
            return Ok(new { Message = "İlan başarıyla eklendi ve onaya gönderildi!" });
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok(new { Message = "İlan başarıyla silindi!" });
        }

        [HttpGet("ApprovedList")]
        public async Task<IActionResult> GetApprovedList()
        {
            var values = await _repository.GetApprovedAsync();

            var dtoList = values.Select(a => new AdvertisementListDto
            {
                Id = a.Id,
                Title = a.Title,
                Price = a.Price,
                RoomCount = a.RoomCount,
                CityName = a.City != null ? a.City.Name : "Belirtilmemiş",
                CategoryName = a.Category != null ? a.Category.Name : "Belirtilmemiş",
                CreatedDate = a.CreatedDate
            }).ToList();

            return Ok(dtoList);
        }

       
        [Authorize] // Eğer rollerin tamsa burayı [Authorize(Roles = "Admin")] yapabilirsin.
        [HttpPut("Approve/{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            await _repository.ApproveAsync(id);
            return Ok(new { Message = "İlan başarıyla onaylandı ve vitrine alındı!" });
        }
 
        [HttpGet("Filter")]
        public async Task<IActionResult> GetFiltered([FromQuery] AdvertisementFilterDto filter)
        {
            var values = await _repository.GetFilteredAsync(filter);

            var dtoList = values.Select(a => new AdvertisementListDto
            {
                Id = a.Id,
                Title = a.Title,
                Price = a.Price,
                RoomCount = a.RoomCount,
                CityName = a.City != null ? a.City.Name : "Belirtilmemiş",
                CategoryName = a.Category != null ? a.Category.Name : "Belirtilmemiş",
                CreatedDate = a.CreatedDate
            }).ToList();

            if (!dtoList.Any())
                return NotFound(new { Message = "Arama kriterlerinize uygun ilan bulunamadı." });

            return Ok(dtoList);
        }
       
        [Authorize] 
        [HttpGet("Pending")]
        public async Task<IActionResult> GetPending()
        {
            var values = await _repository.GetAllAsync();

            var pendingList = values.Where(x => x.IsApproved == false).Select(a => new AdvertisementListDto
            {
                Id = a.Id,
                Title = a.Title,
                Price = a.Price,
                RoomCount = a.RoomCount,
                CityName = a.City != null ? a.City.Name : "Belirtilmemiş",
                CategoryName = a.Category != null ? a.Category.Name : "Belirtilmemiş",
                CreatedDate = a.CreatedDate
            }).ToList();

            return Ok(pendingList);
        }
    }
}