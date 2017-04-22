
using System.Data.Entity;
using Domain.Entities;

namespace Domain.Concrete
{
    class EFDbContext : DbContext
    {
        public DbSet <Product> Products { get; set; }
        public DbSet <Price> Prices { get; set; }
        public DbSet <Platform> Platforms { get; set; }
    }
    
}
