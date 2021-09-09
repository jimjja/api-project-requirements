using Microsoft.EntityFrameworkCore;
using ShalekKavy.Api.Models;
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
            // set primary keys
            modelBuilder.Entity<Beverage>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<AddOns>()
                .HasKey(x => x.Id);

            // set up fields for beverages and addon
            modelBuilder.Entity<Beverage>().Property(x => x.Id).IsRequired();
            modelBuilder.Entity<Beverage>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Beverage>().Property(x => x.Description).IsRequired();
            modelBuilder.Entity<Beverage>().Property(x => x.Ingredients).IsRequired();
            modelBuilder.Entity<Beverage>().Property(x => x.Allergens).IsRequired();
            modelBuilder.Entity<Beverage>().Property(x => x.Availability).IsRequired();
            modelBuilder.Entity<Beverage>().Property(x => x.Allergens).IsRequired();
            modelBuilder.Entity<Beverage>().Property(x => x.Size).IsRequired();
            modelBuilder.Entity<Beverage>().Property(x => x.Price).IsRequired();
            modelBuilder.Entity<Beverage>().Property(x => x.DateCreated).IsRequired();
            modelBuilder.Entity<Beverage>().Property(x => x.DateModified).IsRequired();

            modelBuilder.Entity<AddOns>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<AddOns>().Property(x => x.Availability).IsRequired();
            modelBuilder.Entity<AddOns>().Property(x => x.Type).IsRequired();
            modelBuilder.Entity<AddOns>().Property(x => x.BeverageId).IsRequired();
            modelBuilder.Entity<AddOns>().Property(x => x.Price).IsRequired();
            modelBuilder.Entity<AddOns>().Property(x => x.DateCreated).IsRequired();
            modelBuilder.Entity<AddOns>().Property(x => x.DateModified).IsRequired();
        }

    }
}