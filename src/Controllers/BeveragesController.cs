using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using ShalekKavy.Api.Models.Enums;
using ShalekKavy.Api.Services;
using ShalekKavy.Api.Validation;
using System.Linq;
using System.Threading.Tasks;

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

            if (beverage == null)
            {
                return BadRequest("A beverage with that Id does not exist.");
            }

            return Ok(beverage);
        }
        // GET <BeverageController>/name/{name}
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByBeverageName(string name)
        {
            var beverage = await _repository.GetByBeverageName(name);

            if (beverage == null)
            {
                return BadRequest("A beverage with that name does not exist.");
            }

            return Ok(beverage);
        }
        // GET <BeverageController>/type/{type}
        [HttpGet("type/{type}")]
        public async Task<IActionResult> GetByBeverageType(BeverageType type)
        {
            var beverages = await _repository.GetByBeverageType(type);

            if (!beverages.Any())
            {
                return BadRequest("Beverages of that type do not exist.");
            }

            return Ok(beverages);
        }
        // POST <BeverageController>/add
        [HttpPost("add")]
        public async Task<IActionResult> AddBeverage([FromBody] Beverage beverage)
        {
            // VALIDATION - 1. Instantiate the validator object 
            BeverageValidator validator = new BeverageValidator();

            // VALIDATION - 2. Call the validate method, with the object you want to validate
            ValidationResult result = validator.Validate(beverage);

            // VALIDATION - 3. Check if the results of the validation are not valid 
            if (!result.IsValid)
            {
                var errorMessages = result.ToString("-");
                return BadRequest(errorMessages);
            }

            var beverages = await _repository.GetAll();
            var existingBeverage = beverages.FirstOrDefault(x => x.Id == beverage.Id);
            if (existingBeverage != null)
            {
                return BadRequest("A beverage with the id you have specified already exists. Please use a unique id");
            }
            await _repository.AddBeverage(beverage);
            return Ok(beverage);
        }
        // PUT api/<BeverageController>/update
        [HttpPut("update")]
        public async Task<IActionResult> UpdateBeverage([FromBody] Beverage beverage)
        {
            var beverages = await _repository.GetAll();
            var existingBeverage = beverages.First(x => x.Id == beverage.Id);

            if (existingBeverage == null)
            {
                return BadRequest("A beverage with that id does not exist.");
            }

            // VALIDATION - 1. Instantiate the validator object 
            BeverageValidator validator = new BeverageValidator();

            // VALIDATION - 2. Call the validate method, with the object you want to validate
            ValidationResult result = validator.Validate(beverage);

            // VALIDATION - 3. Check if the results of the validation are not valid 
            if (!result.IsValid)
            {
                var errorMessages = result.ToString("-");
                return BadRequest(errorMessages);
            }

            await _repository.UpdateBeverage(existingBeverage, beverage);

            return Ok();
        }
        // DELETE api/<BeverageController>/delete/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBeverage(string id)
        {
            var beverage = _repository.GetAll().Result.FirstOrDefault(x => x.Id == id);

            if (beverage == null)
            {
                return BadRequest("A beverage with that id does not exist.");
            }
            await _repository.DeleteBeverage(beverage);
            return Ok();
        }
    }
}