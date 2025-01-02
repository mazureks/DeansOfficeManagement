namespace DeansOfficeManagement.Models
{
    public class AdminPanel
    {
        public int AdminPanelId { get; set; }

        // Przykładowe pola związane z zadaniami administratora
        public string? TaskName { get; set; }
        public DateTime Deadline { get; set; }
    }
}
