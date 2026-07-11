using EF_intro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EF_intro
{
    public class AppDbContext : DbContext
    {
        // Таблиці
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Налашутвання підключення
        // Метод переписує батьківський
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string connectionString = "Server=localhost;Database=SPR521_intro;Trusted_Connection=True;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(connectionString);
                //.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
        }

        // Налаштування моделей
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Product
            builder.Entity<Product>(e =>
            {
                // Primary key
                e.HasKey(p => p.Id);

                // Налаштування Name
                e.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

                // Налаштування Price
                e.Property(p => p.Price)
                .HasColumnType("money");

                // Налаштування Description
                e.Property(p => p.Description)
                .HasColumnType("ntext");

                // Налаштування CreatedDate
                e.Property(p => p.CreatedDate);
            });
        }
    }
}
