using System;
using System.ComponentModel.DataAnnotations;

namespace Mission06_DeMann.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        // Required Fields
        public string Title { get; set; }
        public int Year { get; set; }

        // Non-nullable fields (must have a default value)
        public bool Edited { get; set; } = false;  // Default value set to false
        public bool CopiedToPlex { get; set; } = false;  // Default value set to false

        // Additional fields (optional)
        public string Director { get; set; }
        public string Rating { get; set; }
        public string Category { get; set; }
        public string LentTo { get; set; }
        public string Notes { get; set; }
    }

}