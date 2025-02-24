using System.ComponentModel.DataAnnotations;

namespace Mission06_DeMann.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        
        public string CategoryName { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}