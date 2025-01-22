using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DeansOfficeManagement.Models;

namespace DeansOfficeManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Zbiory danych dla każdego modelu
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseRegistration> CourseRegistrations { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<AdminPanel> AdminPanels { get; set; } // Jeśli potrzebne na podstawie funkcjonalności administratora

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Zastosowanie danych początkowych

            modelBuilder.Seed();// Wprowadzenie danych startowych

            // Jeden-do-wielu: Kurs do Ocen
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Course)
                .WithMany(c => c.Grades)
                .HasForeignKey(g => g.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Jeden-do-wielu: Kurs do Rejestracji Kursów
            modelBuilder.Entity<CourseRegistration>()
                .HasOne(cr => cr.Course)
                .WithMany(c => c.CourseRegistrations)
                .HasForeignKey(cr => cr.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Jeden-do-wielu: ApplicationUser (Wykładowca) do Kursów
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Lecturer)
                .WithMany() // Brak właściwości nawigacyjnej po stronie Wykładowcy
                .HasForeignKey(c => c.LecturerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Wiele-do-wielu: Kurs do Studenta (poprzez Rejestrację Kursów)
            modelBuilder.Entity<CourseRegistration>()
                .HasKey(cr => new { cr.CourseId, cr.StudentId });

            modelBuilder.Entity<CourseRegistration>()
                .HasOne(cr => cr.Course)
                .WithMany(c => c.CourseRegistrations)
                .HasForeignKey(cr => cr.CourseId);

            modelBuilder.Entity<CourseRegistration>()
                .HasOne(cr => cr.Student)
                .WithMany() // Brak właściwości nawigacyjnej po stronie Studenta dla rejestracji
                .HasForeignKey(cr => cr.StudentId);
        }

    }
}
