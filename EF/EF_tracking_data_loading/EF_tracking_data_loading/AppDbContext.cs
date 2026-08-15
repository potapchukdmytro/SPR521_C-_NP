using EF_Relationships_seeder.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EF_Relationships_seeder
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<ProgramLanguage> ProgramLanguages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string connectionString = "Server=localhost;Database=SPR521_Relationships;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder
                .UseSqlServer(connectionString);
                //LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // User
            builder.Entity<User>(e =>
            {
                e.HasKey(u => u.Id);

                e.Property(u => u.Name)
                .HasMaxLength(150)
                .IsRequired();

                e.Property(u => u.Country)
                .HasMaxLength(100)
                .IsRequired();
            });

            // ProgramLanguage
            builder.Entity<ProgramLanguage>(e =>
            {
                e.HasKey(pl => pl.Id);

                e.Property(pl => pl.Name)
                .HasMaxLength(100)
                .IsRequired();
            });

            // Role
            builder.Entity<Role>(e =>
            {
                e.HasKey(r => r.Id);

                e.Property(r => r.Name)
                .HasMaxLength(50)
                .IsRequired();
            });

            // Passport
            builder.Entity<Passport>(e =>
            {
                e.HasKey(p => p.Id);

                e.Property(p => p.Number)
                .HasMaxLength(25)
                .IsRequired();

                e.Property(p => p.ReleaseDate)
                .IsRequired();
            });

            // Relationships

            // User <-> Role - one to many
            builder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull); // Дія у класі "User" для зовнішнього ключа "RoleId"яка виконається після видалення ролі

            // User <-> Passport - one to one
            builder.Entity<Passport>()
                .HasOne(p => p.User)
                .WithOne(u => u.Passport)
                .HasForeignKey<Passport>(p => p.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); // Cascade якщо видалити User то автоматично видалиться його Passport

            // User <-> ProgramLanguage - many to many
            builder.Entity<User>()
                .HasMany(u => u.ProgramLanguages)
                .WithMany(pl => pl.Users)
                .UsingEntity("UserProgramLanguages"); // Вказуємо назву проміжної таблиці



            // Seeder - потрібно робити міграцію
            //builder.Entity<Role>()
            //    .HasData([
            //        new Role { Id = 1, Name = "user" },
            //        new Role { Id = 2, Name = "admin" },
            //        new Role { Id = 3, Name = "manager" }
            //        ]);
        }
    }
}
