using EF_Relationships_seeder.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EF_Relationships_seeder
{
    public static class Seeder
    {
        public static void Seed(AppDbContext context)
        {
            // Auto migrations -> update-database
            context.Database.Migrate();


            // Role
            if (!context.Roles.Any())
            {
                Role[] roles = new Role[]
                {
                new Role { Name = "user" },
                new Role { Name = "admin" },
                new Role { Name = "manager" }
                };

                context.Roles.AddRange(roles);
                context.SaveChanges();
            }

            // User and Pasports
            if (!context.Users.Any())
            {
                var roles = context.Roles.ToList();

                var users = new List<User>
                {
                    new()
                    {
                        Name = "John Smith",
                        Age = 25,
                        Country = "USA",
                        Role = roles[1]
                    },
                    new()
                    {
                        Name = "Emma Johnson",
                        Age = 31,
                        Country = "Canada",
                        Role = roles[0]
                    },
                    new()
                    {
                        Name = "Liam Brown",
                        Age = 22,
                        Country = "United Kingdom",
                        Role = roles[0]
                    },
                    new()
                    {
                        Name = "Olivia Davis",
                        Age = 28,
                        Country = "Australia",
                        Role = roles[0]
                    },
                    new()
                    {
                        Name = "Noah Wilson",
                        Age = 35,
                        Country = "Germany",
                        Role = roles[0]
                    },
                    new()
                    {
                        Name = "Sophia Miller",
                        Age = 27,
                        Country = "France",
                        Role = roles[0],
                        Passport = new Passport { Number = "0987654321YY", ReleaseDate = new DateTime(1995, 7, 10) }
                    },
                    new()
                    {
                        Name = "James Anderson",
                        Age = 40,
                        Country = "Italy",
                        Role = roles[2],
                        Passport = new Passport { Number = "9876543210HH", ReleaseDate = new DateTime(1998, 1, 2) }
                    },
                    new()
                    {
                        Name = "Mia Taylor",
                        Age = 24,
                        Country = "Spain",
                        Role = roles[2],
                        Passport = new Passport { Number = "8765432109BB", ReleaseDate = new DateTime(2003, 5, 21) }
                    },
                    new()
                    {
                        Name = "Benjamin Thomas",
                        Age = 33,
                        Country = "Poland",
                        Role = roles[2],
                        Passport = new Passport { Number = "8765432109UU", ReleaseDate = new DateTime(2010, 4, 25) }
                    },
                    new()
                    {
                        Name = "Charlotte Moore",
                        Age = 29,
                        Country = "Ukraine",
                        Role = roles[2],
                        Passport = new Passport { Number = "7654321098QU", ReleaseDate = new DateTime(2008, 12, 31) }
                    }
                };

                context.Users.AddRange(users);
                context.SaveChanges();

                var passports = new List<Passport>
                {
                    new (){ Number = "1234567890AA", ReleaseDate = new DateTime(2000, 1, 1), User = users[0] },
                    new (){ Number = "2345678901AB", ReleaseDate = new DateTime(1998, 2, 12), User = users[1] },
                    new (){ Number = "3456789012AC", ReleaseDate = new DateTime(2002, 10, 22), User = users[2] },
                    new (){ Number = "4567890123AD", ReleaseDate = new DateTime(1990, 5, 30), UserId = users[3].Id },
                    new (){ Number = "5678901234AE", ReleaseDate = new DateTime(2001, 8, 3), UserId = users[4].Id }
                };

                context.Passports.AddRange(passports);
                context.SaveChanges();
            }

            // ProgramLanguages
            if(!context.ProgramLanguages.Any())
            {
                var users = context.Users.ToList();

                var programLanguages = new List<ProgramLanguage>
                {
                    new()
                    {
                        Name = "C",
                        Year = 1972,
                        Users = [users[0], users[3], users[7]]
                    },
                    new()
                    {
                        Name = "C++",
                        Year = 1985,
                        Users = [users[1], users[2]]
                    },
                    new()
                    {
                        Name = "C#",
                        Year = 2000,
                        Users = [users[7], users[9], users[8]]
                    },
                    new()
                    {
                        Name = "Java",
                        Year = 1995,
                        Users = [users[3]]
                    },
                    new()
                    {
                        Name = "Python",
                        Year = 1991,
                        Users = [users[4], users[6], users[2], users[1], users[0]]
                    },
                    new()
                    {
                        Name = "JavaScript",
                        Year = 1995,
                        Users = [users[1], users[2], users[3]]
                    },
                    new()
                    {
                        Name = "TypeScript",
                        Year = 2012,
                        Users = [users[4], users[5], users[6]]
                    },
                    new()
                    {
                        Name = "Go",
                        Year = 2009,
                        Users = [users[7], users[8], users[9]]
                    },
                    new()
                    {
                        Name = "Rust",
                        Year = 2010,
                        Users = [users[1], users[3], users[5]]
                    },
                    new()
                    {
                        Name = "Kotlin",
                        Year = 2011,
                        Users = [users[0], users[2], users[4]]
                    },
                    new()
                    {
                        Name = "Swift",
                        Year = 2014,
                        Users = [users[3], users[6], users[9]]
                    },
                    new()
                    {
                        Name = "PHP",
                        Year = 1995,
                        Users = [users[8], users[4], users[2]]
                    },
                    new()
                    {
                        Name = "Ruby",
                        Year = 1995,
                        Users = [users[7], users[2], users[1]]
                    },
                    new()
                    {
                        Name = "Dart",
                        Year = 2011,
                        Users = [users[2], users[4], users[0]]
                    },
                    new()
                    {
                        Name = "Scala",
                        Year = 2004,
                        Users = [users[6], users[5], users[9]]
                    },
                    new()
                    {
                        Name = "Perl",
                        Year = 1987,
                        Users = [users[1], users[7], users[9]]
                    },
                    new()
                    {
                        Name = "Lua",
                        Year = 1993,
                        Users = [users[0], users[2], users[5]]
                    },
                    new()
                    {
                        Name = "Haskell",
                        Year = 1990,
                        Users = [users[6], users[7], users[8]]
                    },
                    new()
                    {
                        Name = "Elixir",
                        Year = 2011,
                        Users = [users[9], users[5], users[3]]
                    },
                    new()
                    {
                        Name = "F#",
                        Year = 2005,
                        Users = [users[1], users[7], users[4]]
                    }
                };

                context.ProgramLanguages.AddRange(programLanguages);
                context.SaveChanges();
            }

        }
    }
}
