using System.ComponentModel.DataAnnotations;

namespace DeansOfficeManagement.Models.ViewModels
{
    public record SubmitRequestViewModel
    {
        [Required]
        public string? RequestType { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Opis nie może przekraczać 500 znaków.")]
        public string? Description { get; set; }
    }
}
