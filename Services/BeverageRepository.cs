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
        public IEnumerable<Beverage> GetById(string id)
        {
            var beverage = _dbContext.Beverages.Where(x => x.Id == id);
            return beverage;
        }
        public IEnumerable<Beverage> GetByBeverage(string name)
        {
            var beverage = _dbContext.Beverages.Where(x => x.Name == name);
            return beverage;
        }
        public IEnumerable<Beverage> GetByBeverageType(BeverageType type)
        {
            var beverages = _dbContext.Beverages.Where(x => x.BeverageType == type);
            return beverages;
        }
        public void AddBeverage(Beverage beverage)
        {
            _dbContext.Beverages.Add(beverage);
            _dbContext.SaveChanges();
        }
        public void UpdateBeverage(Beverage beverage)
        {
            if (!_dbContext.Beverages.Contains(beverage))
            {
                return;
            }
            _dbContext.Beverages.Update(beverage);
            _dbContext.SaveChanges();
        }
        public void DeleteBeverage(string id)
        {
            var beverage = _dbContext.Beverages.FirstOrDefault(x => x.Id == id);
            if (beverage == null)
            {
                return;
            }
            _dbContext.Beverages.Remove(beverage);
            _dbContext.SaveChanges();
        }
    }
}