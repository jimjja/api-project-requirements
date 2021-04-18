using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShalekKavy.Api.Context
{
    public class SeedDatabase
    {
        public static void SeedDatabaseWithMockData(BeverageContext context)
        {

            context.Database.EnsureCreated();
            /*   context.Database.EnsureDeleted();*/
            SeedDb(context);
        }

        public static void SeedDb(BeverageContext dbContext)
        {
            var json = File.ReadAllText("./Data/Beverages.json");
            var beverages = JsonConvert.DeserializeObject<List<Beverage>>(json);

            if (!dbContext.Beverages.AnyAsync().Result)
            {
                dbContext.AddRange(beverages);
            }


            dbContext.SaveChanges();
        }
    }
}
