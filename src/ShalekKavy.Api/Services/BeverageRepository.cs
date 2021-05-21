using Microsoft.EntityFrameworkCore;
using ShalekKavy.Api.Context;
using ShalekKavy.Api.Models.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShalekKavy.Api.Services
{
    public class BeverageRepository : IBeverageRepository
    {
        private readonly BeverageContext _dbContext;
        public BeverageRepository(BeverageContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Beverage> GetAllBeverages()
        {
            var beverages = _dbContext.Beverages
                .Include(x => x.AddOns)
                .AsNoTracking();

            return beverages;
        }
        public async Task<List<Beverage>> GetAll()
        {
            var beverages = await GetAllBeverages()
                .ToListAsync();

            return beverages;
        }
        public async Task<Beverage> GetById(string id)
        {

            var beverage = await GetAllBeverages()
                .FirstOrDefaultAsync(x => x.Id == id);

            return beverage;
        }
        public async Task<Beverage> GetByBeverageName(string name)
        {
            var beverage = await GetAllBeverages()
                .FirstOrDefaultAsync(x => x.Name == name);

            return beverage;
        }
        public async Task<List<Beverage>> GetByBeverageType(BeverageType type)
        {
            var beverages = await GetAllBeverages()
                .Where(x => x.BeverageType == type)
                .ToListAsync();

            return beverages;
        }
        public async Task AddBeverage(Beverage beverage)
        {
            CheckAndSetPrice(beverage);

            beverage.AddOns?.Select(x =>
            {
                if (x.BeverageId != beverage.Id)
                {
                    x.BeverageId = beverage.Id;
                }

                return x;
            }).ToList();

            _dbContext.Beverages.Add(beverage);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateBeverage(Beverage updatedBeverage)
        {
            CheckAndSetPrice(updatedBeverage);

            updatedBeverage.AddOns?.Select(x =>
            {
                if (x.BeverageId != updatedBeverage.Id)
                {
                    x.BeverageId = updatedBeverage.Id;
                }

                return x;
            }).ToList();

            _dbContext.Beverages.Update(updatedBeverage);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteBeverage(Beverage beverage)
        {
            _dbContext.Beverages.Remove(beverage);
            await _dbContext.SaveChangesAsync();
        }

        public void CheckAndSetPrice(Beverage beverage)
        {
            if (beverage.Size == BeverageSize.Small)
            {
                beverage.Price = 0.5;
            }
            else if (beverage.Size == BeverageSize.Regular)
            {
                beverage.Price = 1;
            }
            else
            {
                beverage.Price = 1.5;
            }
        }
    }
}