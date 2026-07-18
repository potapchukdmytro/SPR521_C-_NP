using EF_Relationships_seeder.Entities;

namespace EF_Relationships_seeder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using AppDbContext context = new AppDbContext();

            Seeder.Seed(context);
        }
    }
}
