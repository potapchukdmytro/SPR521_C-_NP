using EF_intro.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_intro
{
    public class AppDbContext : DbContext
    {
        // Таблиці
        public DbSet<Product> Products { get; set; }

        // Налашутвання підключення
        // Метод переписує батьківський
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string connectionString = "Server=localhost;Database=SPR521_intro;Trusted_Connection=True;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
