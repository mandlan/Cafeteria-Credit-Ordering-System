using Cafeteria_Credit___Ordering_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria_Credit___Ordering_System.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the primary key for Employee
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);
            // Configure the primary key for Restaurant
            modelBuilder.Entity<Restaurant>()
                .HasKey(r => r.Id);
            // Configure the primary key for MenuItem
            modelBuilder.Entity<MenuItem>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<MenuItem>()
                .HasOne(m => m.Restaurant)
                .WithMany(r => r.MenuItems)
                .HasForeignKey(m => m.RestaurantId);
        }
    }
}