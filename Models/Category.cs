using System.ComponentModel.DataAnnotations;

namespace Mission06_DeMann.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; } // Match database column name

        [Required]
        public string CategoryName { get; set; } = string.Empty;

        // Navigation property
        public List<Movie>? Movies { get; set; }
    }
}