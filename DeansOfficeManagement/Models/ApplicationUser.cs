using Azure.Core;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DeansOfficeManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(50)]
        public string? FirstName { get; set; }
        [StringLength(50)]
        public string? LastName { get; set; }
        public string? Role { get; set; } // np. "Student", "Wykładowca", "PracownikDziekanatu"
        [StringLength(20)]
        public string? StudentNumber { get; set; } // Tylko dla studentów, może być null dla innych ról

        // Własności nawigacyjne
        public ICollection<CourseRegistration>? CourseRegistrations { get; set; }
        public ICollection<Request>? Requests { get; set; }
    }
}