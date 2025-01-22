namespace DeansOfficeManagement.Models.ViewModels
{
    public record GradeInputViewModel
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public List<StudentGradeInput>? Students { get; set; }
    }

    public record StudentGradeInput
    {
        public string? StudentId { get; set; }
        public string? StudentName { get; set; }
        public decimal? Grade { get; set; }
    }

}
