using System.ComponentModel.DataAnnotations;

namespace EF_intro.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }
    }
}
