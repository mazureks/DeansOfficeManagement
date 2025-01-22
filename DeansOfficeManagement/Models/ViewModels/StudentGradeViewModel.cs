namespace DeansOfficeManagement.Models.ViewModels
{
    public record StudentGradeViewModel
    {
        public string CourseName { get; set; }
        public decimal GradeValue { get; set; }
        public DateTime DateAssigned { get; set; }
    }

}
