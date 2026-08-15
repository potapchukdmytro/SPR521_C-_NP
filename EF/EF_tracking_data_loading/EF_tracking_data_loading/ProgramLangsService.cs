using EF_Relationships_seeder;
using EF_Relationships_seeder.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_tracking_data_loading
{
    public class ProgramLangsService
    {
        private readonly AppDbContext _context;

        public ProgramLangsService(AppDbContext context)
        {
            _context = context;
        }

        public void PrintLangs()
        {
            var lang = _context.ProgramLanguages.AsNoTracking().ToList();

            foreach (var l in lang)
            {
                Console.WriteLine(l);
            }
        }

        public void UpdateLang()
        {
            // Get id
            Console.Write("Enter id: ");
            string? idStr = Console.ReadLine();
            bool parse = int.TryParse(idStr, out int id);
            if(!parse)
            {
                return;
            }

            // Get name and year
            Console.Write("Enter name: ");
            string? name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name required");
                return;
            }

            Console.Write("Enter year: ");
            string? yearStr = Console.ReadLine();
            parse = int.TryParse(yearStr, out int year);
            if (!parse)
            {
                year = DateTime.Now.Year;
            }

            var oldLang = _context.ProgramLanguages
                .FirstOrDefault(l => l.Id == id);

            if(oldLang != null)
            {
                oldLang.Name = name;
                oldLang.Year = year;
                _context.SaveChanges();
            }
        }

        public void DeleteLang()
        {
            Console.Write("Enter id: ");
            string? idStr = Console.ReadLine();
            bool parse = int.TryParse(idStr, out int id);
            if (!parse)
            {
                return;
            }

            var lang = _context.ProgramLanguages
                .FirstOrDefault(l => l.Id == id);
            if(lang != null)
            {
                _context.Remove(lang);
                _context.SaveChanges();
            }
        }

        public void AddLang()
        {
            Console.Write("Enter name: ");
            string? name = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name required");
                return;
            }

            Console.Write("Enter year: ");
            string? yearStr = Console.ReadLine();
            bool parse = int.TryParse(yearStr, out int year);
            if (!parse)
            {
                year = DateTime.Now.Year;
            }

            var newLang = new ProgramLanguage
            {
                Name = name,
                Year = year
            };

            _context.Add(newLang);
            _context.SaveChanges();
        }
    }
}
