using EF_Relationships_seeder.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_Relationships_seeder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using AppDbContext context = new AppDbContext();

            Seeder.Seed(context);

            // Read data

            // Include - робить підзапит в іншу таблицю для отримання даних. Те саме що JOIN на SQL
            Console.WriteLine("\nRead data\n");
            //var user = context.Users.Include(u => u.Role).First();

            //if(user.Role != null)
            //{
            //    Console.WriteLine(user.Role.Name);
            //}

            // Отримання всіх даних для User
            //var users = context.Users
            //    .Include(u => u.Role)
            //    .Include(u => u.Passport)
            //    .Include(u => u.ProgramLanguages)
            //    .ToList();



            // Варіант без Include

            var role = context.Roles.ToList();
            var users = context.Users.ToList(); // Кожен юзер отримає роль тому ролі були до цього отримані
        }
    }
}
