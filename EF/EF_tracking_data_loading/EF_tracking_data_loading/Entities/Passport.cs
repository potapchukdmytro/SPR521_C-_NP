namespace EF_Relationships_seeder.Entities
{
    public class Passport
    {
        public int Id { get; set; }
        public required string Number { get; set; }
        public DateTime ReleaseDate { get; set; }

        // User one
        public int UserId { get; set; }
        virtual public User? User { get; set; }
    }
}
