using System.ComponentModel.DataAnnotations;

namespace DeansOfficeManagement.Models
{
    public class CourseRegistration
    {
        [Key]
        public int CourseRegistrationId { get; set; }
        public string? Status { get; set; }

        // Klucze obce
        public string? StudentId { get; set; }
        public ApplicationUser? Student { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
