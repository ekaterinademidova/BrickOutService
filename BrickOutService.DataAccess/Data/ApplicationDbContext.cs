using BrickOutService.Models;
using Microsoft.EntityFrameworkCore;

namespace BrickOutService.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<TypeOfDevice> TypesOfDevices { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeOfDevice>().HasData(
                new TypeOfDevice { Id = 1, Name = "Other", Description = "" },
                new TypeOfDevice { Id = 2, Name = "Phone", Description = ""},
                new TypeOfDevice { Id = 3, Name = "Tablet", Description = "" },
                new TypeOfDevice { Id = 4, Name = "Laptop", Description = "" },
                new TypeOfDevice { Id = 5, Name = "Computer", Description = "" },
                new TypeOfDevice { Id = 6, Name = "Game console", Description = "" },
                new TypeOfDevice { Id = 7, Name = "Watch", Description = "" }                
            );

            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Other", Description = "" },
                new Brand { Id = 2, Name = "Apple", Description = "" },
                new Brand { Id = 3, Name = "Samsung", Description = "" },
                new Brand { Id = 4, Name = "Nokia", Description = "" },
                new Brand { Id = 5, Name = "Xiaomi", Description = "" },
                new Brand { Id = 6, Name = "Asus", Description = "" },
                new Brand { Id = 7, Name = "Lenova", Description = "" }
            );
        }
    }
}
