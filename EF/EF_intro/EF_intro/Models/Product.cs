namespace EF_intro.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"{Id}: {Name}. Price: {Price}, Amount: {Amount}";
        }
    }
}
