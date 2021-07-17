using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ShalekKavy.Api.Context
{
    public class BeverageContext : DbContext
    {
        public BeverageContext(DbContextOptions<BeverageContext> options) : base(options) { }
        public DbSet<Beverage> Beverages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var beverageModel = modelBuilder.Entity<Beverage>();

            // Make ID the primary key
            beverageModel.HasKey(x => x.Id);

            beverageModel.Property(x => x.Name).IsRequired();
            beverageModel.Property(x => x.Description).IsRequired();
            beverageModel.Property(x => x.Ingredients).IsRequired();
            beverageModel.Property(x => x.Availability).IsRequired();
            beverageModel.Property(x => x.Size).IsRequired();
            beverageModel.Property(x => x.Price).IsRequired();
            beverageModel.Property(x => x.BeverageType).IsRequired();
            beverageModel.Property(x => x.DateModified).IsRequired();
            beverageModel.Property(x => x.DateCreated).IsRequired();
        }
    }
}