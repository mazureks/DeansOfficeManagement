namespace DeansOfficeManagement.Models.ViewModels
{
    record LecturerDashboardViewModel
    {
        public IEnumerable<Course>? Courses { get; set; }
        // Dodaj inne właściwości w razie potrzeby, takie jak oczekujące zgłoszenia itp.
    }

}