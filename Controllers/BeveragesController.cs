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
        public async Task<IActionResult> GetBeverages()
        {
            var beverages = await _repository.GetAll();
            return Ok(beverages);
        }
        // GET <BeverageController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBeverageById(string id)
        {
            var beverage = await _repository.GetById(id);
            return Ok(beverage);
        }
        // GET <BeverageController>/5
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByBeverageName(string name)
        {
            var data = await _repository.GetByBeverageName(name);
            return Ok(data);
        }
        // GET <BeverageController>/5
        [HttpGet("type/{type}")]
        public async Task<IActionResult> GetByBeverageType(BeverageType type)
        {
            var data = await _repository.GetByBeverageType(type);
            return Ok(data);
           
        }
        // POST <BeverageController>
        [HttpPost]
        public async Task<IActionResult> AddBeverage([FromBody] Beverage beverage)
        {
            var beverages = await _repository.GetAll();
            var existingBeverage = beverages.Contains(beverage);
            if (existingBeverage)
            {
                return BadRequest("The Id already exists in the databse. Please use another Id value.");
            }
            _repository.AddBeverage(beverage);
            return Ok(beverage);
        }
        // PUT api/<BeverageController>/
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateExistingBeverage(string id, [FromBody] Beverage beverage)
        {
            var beverages = await _repository.GetAll();
            var existingBeverage = beverages.Where(x => x.Id == id);

            if (existingBeverage == null)
            {
                return BadRequest("The beverage does not exist in the database.");
            }

            _repository.UpdateBeverage(beverage);

            return Ok();
        }
        // DELETE api/<BeverageController>/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteExistingBeverage(string id)
        {
            var beverages = await _repository.GetAll();
            var existingBeverage = beverages.Where(x => x.Id == id);

            if(!existingBeverage.Any())
            {
                return BadRequest("The beverage does not exist in the database.");
            }

            _repository.DeleteBeverage(id);
            return Ok();
        }
    }
}