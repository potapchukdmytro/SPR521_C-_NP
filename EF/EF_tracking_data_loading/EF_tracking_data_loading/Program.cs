using EF_Relationships_seeder.Entities;
using EF_tracking_data_loading;
using Microsoft.EntityFrameworkCore;

namespace EF_Relationships_seeder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using AppDbContext context = new AppDbContext();

            Seeder.Seed(context);

            //Role? role = context.Roles.FirstOrDefault(r => r.Name == "writer");
            //if (role != null)
            //{
            //    // Переглянути state entity
            //    Console.WriteLine(context.Entry(role).State);
            //    role.Name = "manager";
            //    Console.WriteLine(context.Entry(role).State);
            //    context.SaveChanges();
            //}


            // Стани
            // added - слідкування. Запит insert
            // modified - слідкування. Запит update
            // deleted - слідкування. Запит delete
            // unchanged - слідкування. Запиту не буде
            // detached - не слідкує


            //Role roleUpdated = new Role
            //{
            //    Id = 3,
            //    Name = "manager"
            //};
            //Console.WriteLine(context.Entry(roleUpdated).State);
            //context.Entry(roleUpdated).State = EntityState.Modified;
            //context.Roles.Update(roleUpdated);
            //Role newRole = new Role
            //{
            //    Name = "writer"
            //};
            //context.Entry(newRole).State = EntityState.Added;

            //context.SaveChanges();


            // AsNoTracking

            // AsNoTracking - для всіх entity вказує state detached
            //var roles = context.Roles.AsNoTracking().ToList();

            //Role? role = context.Roles.FirstOrDefault(r => r.Name == "manager");
            //context.Entry(role).State = EntityState.Detached;

            //Role? role = context.Roles.AsNoTracking().FirstOrDefault(r => r.Name == "reader");

            //Role reader = new Role
            //{
            //    Id = 3,
            //    Name = "reader"
            //};
            //Console.WriteLine(context.Entry(reader).State);

            //context.Update(reader);
            //Console.WriteLine(context.Entry(reader).State);

            //context.SaveChanges();



            ProgramLangsService service = new ProgramLangsService(context);
            while(true)
            {
                Console.Clear();
                service.PrintLangs();

                Console.WriteLine();
                Console.WriteLine("1. Add new language");
                Console.WriteLine("2. Update language");
                Console.WriteLine("3. Delete language");
                ConsoleKey key = Console.ReadKey(true).Key;

                switch(key)
                {
                    case ConsoleKey.D1:
                        service.AddLang();
                        break;
                    case ConsoleKey.D2:
                        service.UpdateLang();
                        break;
                    case ConsoleKey.D3:
                        service.DeleteLang();
                        break;
                }
            }
        }
    }
}
