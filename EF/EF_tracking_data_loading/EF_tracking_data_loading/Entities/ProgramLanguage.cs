namespace EF_Relationships_seeder.Entities
{
    public class ProgramLanguage
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Year { get; set; }

        // User many
        virtual public List<User> Users { get; set; } = [];

        public override string ToString()
        {
            return $"{Id}: {Name}, Release - {Year}";
        }
    }
}
