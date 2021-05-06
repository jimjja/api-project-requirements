using Microsoft.EntityFrameworkCore;
using ShalekKavy.Api.Context;
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
                .ToListAsync();
            return beverages;
        }
        public async Task<Beverage> GetById(string id)
        {
            var beverage = await _dbContext.Beverages.FirstOrDefaultAsync(x => x.Id == id);
            return beverage;
        }
        public async Task<Beverage> GetByBeverageName(string name)
        {
            var beverage = await _dbContext.Beverages.FirstOrDefaultAsync(x => x.Name == name);

            return beverage;
        }
        public async Task<List<Beverage>> GetByBeverageType(BeverageType type)
        {
            var beverages = await _dbContext.Beverages.Where(x => x.BeverageType == type).ToListAsync();

            return beverages;
        }
        public async Task AddBeverage(Beverage beverage)
        {
            CheckAndSetPrice(beverage);
            _dbContext.Beverages.Add(beverage);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateBeverage(Beverage existingBeverage, Beverage updatedBeverage)
        {
            existingBeverage.Name = updatedBeverage.Name;
            existingBeverage.Description = updatedBeverage.Description;
            existingBeverage.BeverageType = updatedBeverage.BeverageType;
            existingBeverage.Ingredients = updatedBeverage.Ingredients;
            existingBeverage.Allergens = updatedBeverage.Allergens;
            existingBeverage.DateCreated = updatedBeverage.DateCreated;
            existingBeverage.DateModified = updatedBeverage.DateModified;
            existingBeverage.Availability = updatedBeverage.Availability;
            existingBeverage.Size = updatedBeverage.Size;

            CheckAndSetPrice(updatedBeverage);
            existingBeverage.Price = updatedBeverage.Price;

            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteBeverage(Beverage beverage)
        { 
             _dbContext.Beverages.Remove(beverage);
            await _dbContext.SaveChangesAsync();
        }

        public void CheckAndSetPrice(Beverage beverage)
        {
            if(beverage.Size == Models.BeverageSize.Small)
            {
                beverage.Price = -0.5;
            } else if(beverage.Size == Models.BeverageSize.Regular)
            {
                beverage.Price = 0;
            } else
            {
                beverage.Price = 1;
            }
        }
    }
}