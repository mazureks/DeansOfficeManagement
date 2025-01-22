using Microsoft.EntityFrameworkCore;
using DeansOfficeManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace DeansOfficeManagement.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Wypełnianie początkowe ról
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "ADMIN", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "LECTURER", NormalizedName = "LECTURER" },
                new IdentityRole { Name = "STUDENT", NormalizedName = "STUDENT" }
            );

            /*
            // Wypełnianie początkowe użytkowników
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "1", // Użyj GUID lub unikalnego identyfikatora, jeśli Twój klucz główny jest ciągiem znaków
                    UserName = "admin@deanoffice.com",
                    Email = "admin@deanoffice.com",
                    EmailConfirmed = true,
                    // PasswordHash powinien być zahaszowany w prawdziwej aplikacji; to tylko demonstracja.
                    PasswordHash = "hashed_password_for_admin",
                },
                new ApplicationUser
                {
                    Id = "2",
                    UserName = "lecturer@deanoffice.com",
                    Email = "lecturer@deanoffice.com",
                    EmailConfirmed = true,
                    PasswordHash = "hashed_password_for_lecturer",
                }
            );

            // Wypełnianie początkowe kursów
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = 1,
                    CourseName = "Matematyka dyskretna",
                    Credits = 3,
                    LecturerId = "2" // Zakładając, że ten kurs jest prowadzony przez wykładowcę zainicjowanego powyżej
                },
                new Course
                {
                    CourseId = 2,
                    CourseName = "Fizyka doświadczalna",
                    Credits = 4,
                    LecturerId = "2"
                }
            );

            // Wypełnianie początkowe studentów
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "3",
                    UserName = "student1@deanoffice.com",
                    Email = "student1@deanoffice.com",
                    EmailConfirmed = true,
                    PasswordHash = "hashed_password_for_student1",
                },
                new ApplicationUser
                {
                    Id = "4",
                    UserName = "student2@deanoffice.com",
                    Email = "student2@deanoffice.com",
                    EmailConfirmed = true,
                    PasswordHash = "hashed_password_for_student2",
                }
            );

            // Wypełnianie początkowe rejestracji kursów
            modelBuilder.Entity<CourseRegistration>().HasData(
                new CourseRegistration
                {
                    CourseId = 1,
                    StudentId = "3"
                },
                new CourseRegistration
                {
                    CourseId = 2,
                    StudentId = "4"
                }
            );

            // Wypełnianie początkowe wniosków
            modelBuilder.Entity<Request>().HasData(
                new Request
                {
                    RequestId = 1,
                    RequestType = "Prośba o transkrypt",
                    Description = "Student poprosił o transkrypt.",
                    Status = "Oczekujące",
                    StudentId = "3"
                },
                new Request
                {
                    RequestId = 2,
                    RequestType = "Prośba o zmianę kursu",
                    Description = "Student poprosił o zmianę kursu.",
                    Status = "Zatwierdzone",
                    StudentId = "4"
                }
            );

            // Wypełnianie początkowe ocen
            modelBuilder.Entity<Grade>().HasData(
                new Grade
                {
                    GradeId = 1,
                    CourseId = 1,
                    StudentId = "3",
                    Score = 85
                },
                new Grade
                {
                    GradeId = 2,
                    CourseId = 2,
                    StudentId = "4",
                    Score = 90
                }
            );   */
        }
    }
}
