using Microsoft.EntityFrameworkCore;

namespace ShalekKavy.Api.Context
{
    public class BeverageContext : DbContext
    {
        public BeverageContext(DbContextOptions<BeverageContext> options) : base(options) { }
        public DbSet<Beverage> Beverages { get; set; }
    }
}