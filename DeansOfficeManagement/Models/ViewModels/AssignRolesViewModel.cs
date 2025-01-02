using System.ComponentModel.DataAnnotations;

namespace DeansOfficeManagement.Models.ViewModels
{
    public record AssignRolesViewModel
    {
        // Przechowuje ID użytkownika, któremu przypisywane są role
        [Required]
        public string? UserId { get; set; }

        // Przechowuje wybrane role do przypisania użytkownikowi
        [Required]
        public List<string> SelectedRoles { get; set; } = new List<string>();

        // Przechowuje listę wszystkich dostępnych ról do wyboru
        public List<string> AvailableRoles { get; set; } = new List<string>();

        // Przechowuje listę wszystkich użytkowników, z których dziekan może wybrać
        public List<UserViewModel> Users { get; set; } = new List<UserViewModel>();
    }

    // Oddzielny model reprezentujący informacje o użytkowniku w widoku
    public record UserViewModel
    {
        public string? Id { get; set; } // ID użytkownika
        public string? Email { get; set; } // Email użytkownika do wyświetlania
        public string FirstName { get; set; } // Imię użytkownika
        public string LastName { get; set; } // Nazwisko użytkownika
    }
}