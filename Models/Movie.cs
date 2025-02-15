using System.ComponentModel.DataAnnotations;

namespace Mission06_DeMann.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        [Range(1888, 2099, ErrorMessage = "Please enter a valid year.")]
        public int Year { get; set; } // Added Year field

        [Required]
        public string Director { get; set; } = string.Empty;

        [Required]
        public string Rating { get; set; } = string.Empty;

        [MaxLength(25)]
        public string? Notes { get; set; } // Nullable

        public bool Edited { get; set; } = false;

        public string? LentTo { get; set; } // Nullable
    }
}