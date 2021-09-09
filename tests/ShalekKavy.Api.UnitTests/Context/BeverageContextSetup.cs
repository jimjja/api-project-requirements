using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShalekKavy.Api.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ShalekKavy.Api.UnitTests.Context
{
    public class BeverageContextSetup
    {
        protected DbContextOptions<BeverageContext> ContextOptions { get; }
        public BeverageContextSetup(DbContextOptions<BeverageContext> options)
        {
            ContextOptions = options;

            SeedDatabase();
        }

        public void SeedDatabase()
        {
            using (var context = new BeverageContext(ContextOptions))
            {
                var json = File.ReadAllText("./Data/Beverages.json");
                var beverages = JsonConvert.DeserializeObject<List<Beverage>>(json);

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Beverages.AddRange(beverages);
                context.SaveChanges();
            }
        }
    }
}
