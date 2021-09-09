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
        public async Task<List<Beverage>> GetAll()
        {
            var beverages = await _dbContext.Beverages
                .Include(x => x.AddOns)
                .ToListAsync();

            return beverages;
        }
        public async Task<Beverage> GetById(string id)
        {

            var beverage = await _dbContext.Beverages
                .Include(x => x.AddOns)
                .FirstOrDefaultAsync(x => x.Id == id);

            return beverage;
        }
        public async Task<Beverage> GetByBeverageName(string name)
        {
            var beverage = await _dbContext.Beverages
                .Include(x => x.AddOns)
                .FirstOrDefaultAsync(x => x.Name == name);

            return beverage;
        }
        public async Task<List<Beverage>> GetByBeverageType(BeverageType type)
        {
            var beverages = await _dbContext.Beverages
                .Where(x => x.BeverageType == type)
                .Include(x => x.AddOns)
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
            var beverage = _dbContext.Beverages.FirstOrDefault(x => x.Id == updatedBeverage.Id);

            //_dbContext.Entry(updatedBeverage).State = EntityState.Detached;
            //_dbContext.Beverages.Update(updatedBeverage);
            //await _dbContext.SaveChangesAsync();
            _dbContext.Beverages.Remove(beverage);
            _dbContext.Beverages.Add(updatedBeverage);
            
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteBeverage(Beverage beverage)
        {
            _dbContext.Beverages.Remove(beverage);
            await _dbContext.SaveChangesAsync();
        }

        public void CheckAndSetPrice(Beverage beverage)
        {
            // using dictionary
            var beveragePrices = new Dictionary<BeverageSize, double>()
            {
                { BeverageSize.Small, 0.5 },
                { BeverageSize.Regular, 1 },
                { BeverageSize.Large, 1.5 }
            };

            foreach (KeyValuePair<BeverageSize, double> price in beveragePrices)
            {
                if (price.Key == beverage.Size)
                {
                    beverage.Price = price.Value;
                }
            }

        }
        }
    }