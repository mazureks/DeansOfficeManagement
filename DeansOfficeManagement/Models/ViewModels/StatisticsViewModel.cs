namespace DeansOfficeManagement.Models.ViewModels
{
    public class StatisticsViewModel
    {
        // Dane studentów
        public List<StudentData> TopStudents { get; set; } // Dane studentów

        // Dane wykładowców
        public List<LecturerData> LecturerStatistics { get; set; } // Dane wykładowców
    }

    public class StudentData
    {
        public string StudentName { get; set; } // Imię i nazwisko studenta
        public double WeightedAverage { get; set; } // Średnia ważona ocen
        public int CourseCount { get; set; } // Liczba kursów, w których student uczestniczył
    }

    public class LecturerData
    {
        public string LecturerName { get; set; } // Imię i nazwisko wykładowcy
        public int CourseCount { get; set; } // Liczba kursów prowadzonych przez wykładowcę
        public int TotalCredits { get; set; } // Suma punktów ECTS kursów wykładowcy
    }
}
