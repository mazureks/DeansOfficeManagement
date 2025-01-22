namespace DeansOfficeManagement.Models
{
    public class Request
    {
        public int RequestId { get; set; }
        public string RequestType { get; set; } // np. "Urlop", "Przedłużenie egzaminu"
        public string Description { get; set; }
        public DateTime DateSubmitted { get; set; }
        public string Status { get; set; } // np. "Oczekujące", "Zatwierdzone", "Odrzucone"

        // Klucze obce
        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; }
    }
}





