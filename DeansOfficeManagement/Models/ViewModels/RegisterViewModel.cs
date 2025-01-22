using System.ComponentModel.DataAnnotations;

namespace DeansOfficeManagement.Models.ViewModels
{
    public record RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Hasło i potwierdzenie hasła nie są zgodne.")]
        public string? ConfirmPassword { get; set; }
    }
}