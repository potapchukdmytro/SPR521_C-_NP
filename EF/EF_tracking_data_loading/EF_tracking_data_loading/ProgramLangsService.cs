using EF_Relationships_seeder;

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
            var lang = _context.ProgramLanguages.ToList();

            foreach (var l in lang)
            {
                Console.WriteLine(l);
            }
        }
    }
}
