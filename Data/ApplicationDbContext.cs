using CMSBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace CMSBackend.Data
{


    public class ApplicationDbContext:DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderedItem> OrderedItems{ get; set; }

     /*   protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Admin",Email="admin@gmail.com",Password="admin123456",
                    ContactNumber="9977859801",Role="ADMIN",Status=1 }
                

                );
        }*/

    }
}
