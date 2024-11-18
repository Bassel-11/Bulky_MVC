using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CatigoryId = 1, Name = "Action", DisplayOrder = 1 },
                new Category { CatigoryId = 2, Name = "Scifi", DisplayOrder = 2},
                new Category { CatigoryId = 3, Name = "History", DisplayOrder = 3},
                new Category { CatigoryId = 4, Name = "DarkRomance", DisplayOrder = 4 }
                );
        }
    }
}
