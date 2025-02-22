using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_DeMann.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        public string? Director { get; set; }

        [Required]
        public bool Edited { get; set; }

        [Required]
        public bool CopiedToPlex { get; set; }

        public string? Notes { get; set; }

        // Add the Rating property (it could be a string or a decimal, depending on your needs)
        public string? Rating { get; set; }

        // Add the LentTo property (string to track the person it is lent to)
        public string? LentTo { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}