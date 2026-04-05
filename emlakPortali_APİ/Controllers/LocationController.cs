using emlakPortali_APİ.Models;
using Microsoft.AspNetCore.Mvc;
using emlakPortali_APİ.Models;
using emlakPortali_APİ.Repositories;

namespace emlakPortali_APİ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationRepository _repository;

        public LocationController(LocationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<List<Location>> GetList()
        {
            return await _repository.GetListAsync();
        }
    }
}