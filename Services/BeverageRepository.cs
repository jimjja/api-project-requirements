using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShalekKavy.Api.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace ShalekKavy.Api.Services
{
    public class BeverageRepository : IBeverageRepository
    {
        private BeverageContext _dbContext;
        public BeverageRepository(BeverageContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Beverage>> GetAll()
        {
            var beverages = await _dbContext.Beverages
                .ToListAsync();
            return beverages;
        }
        public async Task<Beverage> GetById(string id)
        {
            var beverage = await _dbContext.Beverages.FirstOrDefaultAsync(x => x.Id == id);
            return beverage;
        }
        public async Task<List<Beverage>> GetByBeverageName(string name)
        {
            var beverage = await _dbContext.Beverages.Where(x => x.Name == name).ToListAsync();
            return beverage;
        }
        public Task<List<Beverage>> GetByBeverageType(BeverageType type)
        {
            var beverages = _dbContext.Beverages.Where(x => x.BeverageType == type).ToListAsync();
            return beverages;
        }
        public void AddBeverage(Beverage beverage)
        {
            _dbContext.Beverages.Add(beverage);
            _dbContext.SaveChanges();
        }
        public void UpdateBeverage(Beverage beverage)
        {
            var updatedBeverage = beverage;
            _dbContext.Beverages.Update(updatedBeverage);
            _dbContext.SaveChanges();
        }
        public void DeleteBeverage(string id)
        {
            var beverage = _dbContext.Beverages.First(x => x.Id == id);

            _dbContext.Beverages.Remove(beverage);
            _dbContext.SaveChanges();
        }
    }
}