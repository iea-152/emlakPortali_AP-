using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using emlakPortali_APİ.Models;
using emlakPortali_APİ.Repositories;

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
        public async Task<IActionResult> GetAll()
        {
            var values = await _repository.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            if (value == null) return NotFound();
            return Ok(value);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(Advertisement advertisement)
        {
            await _repository.AddAsync(advertisement);
            return Ok(new { Message = "İlan başarıyla eklendi!" });
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(Advertisement advertisement)
        {
            await _repository.UpdateAsync(advertisement);
            return Ok(new { Message = "İlan başarıyla güncellendi!" });
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok(new { Message = "İlan başarıyla silindi!" });
        }
    }
}