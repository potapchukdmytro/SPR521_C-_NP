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



            //ProgramLangsService service = new ProgramLangsService(context);
            //while(true)
            //{
            //    Console.Clear();
            //    service.PrintLangs();

            //    Console.WriteLine();
            //    Console.WriteLine("1. Add new language");
            //    Console.WriteLine("2. Update language");
            //    Console.WriteLine("3. Delete language");
            //    ConsoleKey key = Console.ReadKey(true).Key;

            //    switch(key)
            //    {
            //        case ConsoleKey.D1:
            //            service.AddLang();
            //            break;
            //        case ConsoleKey.D2:
            //            service.UpdateLang();
            //            break;
            //        case ConsoleKey.D3:
            //            service.DeleteLang();
            //            break;
            //    }
            //}





            Console.WriteLine("\n\nMAIN\n");
            // Data loading


            // Eager loading (Include)
            // Жадібне завантаження

            //var user = context.Users
            //    .Include(u => u.Passport)
            //    .Include(u => u.ProgramLanguages)
            //    .FirstOrDefault(u => u.Id == 1);
            //if(user != null)
            //{
            //    Console.WriteLine(user.Passport.Number);

            //    foreach (var pl in user.ProgramLanguages)
            //    {
            //        Console.WriteLine(pl.Name);
            //    }
            //}


            // ThenInclude
            //var language = context.ProgramLanguages
            //    .Include(p => p.Users)
            //    .ThenInclude(u => u.Passport)
            //    .First();

            //foreach (var user in language.Users)
            //{
            //    Console.WriteLine(user.Passport.Number);
            //}




            // Explicit loading
            // Явне завантаження

            //var user = context.Users.First();

            //context.Entry(user).Reference(u => u.Passport).Load();

            //Console.WriteLine(user.Passport.Number);

            //UserService service = new UserService(context);
            //string passportNum = service.PassportNumber(5);
            //var langs = service.GetLanguages(2);
            //Console.WriteLine(passportNum);


            // Lazy loading - не рекомендовано використовувати
            // Ліниве завантаження
            // пакет Microsoft.EntityFrameworkCore.Proxies
            // всі navigation property мають бути virtual
            // у DbContext OnConfiguring додати UseLazyLoadingProxies()

            //var users = context.Users.ToList();

            //foreach (var user in users)
            //{
            //    Console.WriteLine(user.Name);
            //    foreach (var pl in user.ProgramLanguages)
            //    {
            //        Console.WriteLine("\t" + pl.Name);
            //    }
            //}
            //Console.WriteLine(user.Passport.Number);




            // IQueryable - відкладений запит
            // Запит відправиться коли ми ці дані почнемо використовувати або колецію перетворимо у List або Array

            //var languages = context.ProgramLanguages.AsQueryable();
            //string request = "SELECT * FROM Languages";

            //languages = languages.Where(l => l.Year >= 2000);
            //request = "SELECT * FROM Languages WHERE Year >= 2000";

            //languages = languages.OrderBy(l => l.Name);
            //request = "SELECT * FROM Languages WHERE Year >= 2000 ORDER BY Name";

            //foreach (var l in languages) // send request
            //{
            //    Console.WriteLine(l.Name);
            //}


            ProgramLangsService service = new ProgramLangsService(context);
            var langs = service.GetAll(l => l.Year < 2000, true);

            foreach (var lang in langs)
            {
                Console.WriteLine(lang.Name);
            }
        }
    }
}
