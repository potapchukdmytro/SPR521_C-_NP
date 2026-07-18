using EF_Relationships_seeder.Entities;

namespace EF_Relationships_seeder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using AppDbContext context = new AppDbContext();

            //Role role = new Role
            //{
            //    Name = "user"
            //};

            //User user = new User
            //{
            //    Name = "John",
            //    Country = "USA",
            //    Age = 50,
            //    Role = role
            //};

            //context.Roles.Add(role);
            //context.Users.Add(user);
            //context.SaveChanges();

            //Passport passport = new Passport
            //{
            //    Number = "1348921741US",
            //    ReleaseDate = new DateTime(1992, 5, 10),
            //    UserId = 1
            //};

            //context.Passports.Add(passport);
            //context.SaveChanges();
        }
    }
}
