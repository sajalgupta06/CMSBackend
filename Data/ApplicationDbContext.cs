using CMSBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace CMSBackend.Data
{
<<<<<<< HEAD
    public class ApplicationDbContext : DbContext
=======
    public class ApplicationDbContext:DbContext
>>>>>>> 33bc538e583e58db3fd106839eebd7ead74aa463
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        /*    protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                    new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                    new Category { Id = 3, Name = "History", DisplayOrder = 3 }

                    );
            }*/

    }
}
