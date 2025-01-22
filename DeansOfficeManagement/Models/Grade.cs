using System.ComponentModel.DataAnnotations;

namespace DeansOfficeManagement.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        [Range(0, 100)]
        public int Score { get; set; } // np. 85.5 dla wyniku procentowego
        public string? GradeLetter { get; set; } // Opcjonalnie, np. "A", "B" itp.

        // Klucze obce
        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}