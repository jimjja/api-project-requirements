using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShalekKavy.Api.Context;
using System.Collections.Generic;
using System.IO;

namespace ShalekKavy.Api.Extensions
{
    public class SeedDatabaseWithMockData
    {
        public static void SeedDatabase(BeverageContext context)
        {
            context.Database.EnsureCreated();
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
