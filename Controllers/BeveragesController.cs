using Microsoft.AspNetCore.Mvc;
using ShalekKavy.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace ShalekKavy.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BeveragesController : ControllerBase
    {
        private readonly IBeverageRepository _repository;
        public BeveragesController(IBeverageRepository repository)
        {
            _repository = repository;
        }
        // GET: BeverageController>
        [HttpGet]
        public Task<List<Beverage>> Get()
        {
            var beverages = _repository.GetAll();
            return beverages;
        }
        // GET <BeverageController>/5
        [HttpGet("{id}")]
        public IEnumerable<Beverage> GetById(string id)
        {
            return _repository.GetById(id);
        }
        // GET <BeverageController>/5
        [HttpGet("name/{name}")]
        public IEnumerable<Beverage> GetByBeverage(string name)
        {
            return _repository.GetByBeverage(name);
        }
        // GET <BeverageController>/5
        [HttpGet("type/{type}")]
        public IEnumerable<Beverage> GetByBeverage(BeverageType type)
        {
            return _repository.GetByBeverageType(type);
        }
        // POST <BeverageController>
        [HttpPost]
        public async Task<IActionResult> AddBeverage([FromBody] Beverage beverage)
        {
            var beverages = await _repository.GetAll();
            var existingBeverage = beverages.Contains(beverage);
            if (existingBeverage)
            {
                return BadRequest();
            }
            _repository.AddBeverage(beverage);
            return Ok(beverage);
        }
        // PUT api/<BeverageController>/
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Beverage beverage)
        {
            _repository.UpdateBeverage(beverage);
        }
        // DELETE api/<BeverageController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _repository.DeleteBeverage(id);
        }
    }
}