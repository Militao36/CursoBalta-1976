using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data.Maps;
using ProductCatalog.Models;

namespace ProductCatalog.Data
{
    public class StoreDataContext : DbContext
    {
        public DbSet<Product> Procuts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optiopnsBuilder)
        {
            optiopnsBuilder.UseSqlServer(@"Server=DESKTOP-DA2JGED;Database=prodcat;User ID=SA;Password=Matheus@147sa");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new CategoryMap());
        }
    }
}