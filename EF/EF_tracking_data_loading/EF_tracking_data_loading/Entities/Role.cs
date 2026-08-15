namespace EF_Relationships_seeder.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        // User many
        virtual public List<User> Users { get; set; } = []; // Navigation property
    }
}
