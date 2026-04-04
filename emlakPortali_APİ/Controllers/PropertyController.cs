using Microsoft.AspNetCore.Mvc;
using emlakPortali_APİ.Models;
using Uyg.API.Repositories;

namespace Uyg.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly PropertyRepository _repository;
        private Result _result = new Result();

        public PropertyController(PropertyRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<List<Property>> GetList()
        {
            return await _repository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Property> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<Result> Add(Property model)
        {
            await _repository.AddAsync(model);
            _result.Status = true;
            _result.Message = "Property Added Successfully";
            return _result;
        }

        [HttpPut]
        public async Task<Result> Update(Property model)
        {
            await _repository.UpdateAsync(model);
            _result.Status = true;
            _result.Message = "Property Updated Successfully";
            return _result;
        }

        [HttpDelete("{id}")]
        public async Task<Result> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            _result.Status = true;
            _result.Message = "Property Deleted Successfully";
            return _result;
        }
    }
}