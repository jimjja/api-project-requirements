using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShalekKavy.Api.Services
{
    public interface IBeverageRepository
    {
        public List<Beverage> GetAll();
        public IEnumerable<Beverage> GetById(string id);
        public IEnumerable<Beverage> GetByBeverage(string name);
        public IEnumerable<Beverage> GetByBeverageType(BeverageType type);
    }
}
