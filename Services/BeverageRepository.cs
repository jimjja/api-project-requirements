using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShalekKavy.Api.Services
{
    public class BeverageRepository : IBeverageRepository
    {
        public List<Beverage> GetAll()
        {
            // read file and deserialize json
            var contentRootPath = Directory.GetCurrentDirectory();

            var data = File.ReadAllText(contentRootPath + "/Data/Beverages.json");

            var deserializeContent = JsonConvert.DeserializeObject<List<Beverage>>(data);

            return deserializeContent;
        }

        public IEnumerable<Beverage> GetById(string id)
        {
            
            var contentRootPath = Directory.GetCurrentDirectory();

            var data = File.ReadAllText(contentRootPath + "/Data/Beverages.json");

            var deserializeContent = JsonConvert.DeserializeObject<List<Beverage>>(data);

            var beverage = deserializeContent.Where(x => x.Id == id);

            return beverage;
        }

        public IEnumerable<Beverage> GetByBeverage(string name)
        {
            // read file and deserialize json
            var contentRootPath = Directory.GetCurrentDirectory();

            var data = File.ReadAllText(contentRootPath + "/Data/Beverages.json");

            var deserializeContent = JsonConvert.DeserializeObject<List<Beverage>>(data);

            var beverage = deserializeContent.Where(x => x.Name == name);

            return beverage;
        }

        public IEnumerable<Beverage> GetByBeverageType(BeverageType type)
        {
            // read file and deserialize json
            var contentRootPath = Directory.GetCurrentDirectory();

            var data = File.ReadAllText(contentRootPath + "/Data/Beverages.json");

            var deserializeContent = JsonConvert.DeserializeObject<List<Beverage>>(data);

            var beverages = deserializeContent.Where(x => x.BeverageType == type);

            return beverages;
        }
    }
}
