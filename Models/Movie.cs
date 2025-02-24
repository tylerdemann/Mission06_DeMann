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

        // Make Director, Rating, LentTo, and Notes nullable to accommodate null values in the DB
        public string? Director { get; set; } 
        public int? CategoryId { get; set; }
        public Category? Category { get; set; } // Foreign key navigation property (nullable)

        public string? Rating { get; set; } // Nullable
        public string? LentTo { get; set; } // Nullable

        [Required]
        public bool CopiedToPlex { get; set; }

        [Required]
        public bool Edited { get; set; }

        public string? Notes { get; set; } // Nullable
    }
}