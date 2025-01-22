using System.ComponentModel.DataAnnotations;

namespace DeansOfficeManagement.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        [StringLength(100)]
        public string? CourseName { get; set; }

        public int Credits { get; set; }

        // Klucze obce
        public string? LecturerId { get; set; }
        public ApplicationUser? Lecturer { get; set; }

        // Właściwości nawigacyjne
        public ICollection<CourseRegistration> CourseRegistrations { get; set; } = new List<CourseRegistration>();
        public ICollection<Grade> Grades { get; set; } = new List<Grade>(); // Do zarządzania ocenami
    }
}