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
        public List<Beverage> Get()
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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BeverageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BeverageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
