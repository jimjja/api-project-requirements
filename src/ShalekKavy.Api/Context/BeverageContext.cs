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
    }
}