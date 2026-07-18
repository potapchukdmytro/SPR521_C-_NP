namespace EF_Relationships_seeder.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }
        public required string Country { get; set; }

        // Role one
        public int? RoleId { get; set; } // Foreign key. Створиться у вигляді колонки в таблиці
        public Role? Role { get; set; } // Navigation property

        // Passport one
        public Passport? Passport { get; set; }

        // ProgramLanguage many
        public List<ProgramLanguage> ProgramLanguages { get; set; } = [];
    }
}
