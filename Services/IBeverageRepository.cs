using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ShalekKavy.Api.Services
{
    public interface IBeverageRepository
    {
        public Task<List<Beverage>> GetAll();
        public Task<Beverage> GetById(string id);
        public Task<List<Beverage>> GetByBeverageName(string name);
        public Task<List<Beverage>> GetByBeverageType(BeverageType type);
        public void AddBeverage(Beverage beverage);
        public void UpdateBeverage(Beverage beverage);
        public void DeleteBeverage(string id);
    }
}