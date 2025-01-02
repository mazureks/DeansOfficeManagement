using DeansOfficeManagement.Data;
using DeansOfficeManagement.Models;
using DeansOfficeManagement.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DeansOfficeManagement.Controllers
{
    [Authorize(Roles = "LECTURER")]
    public class LecturerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public LecturerController(UserManager<ApplicationUser> userManager,
                               RoleManager<IdentityRole> roleManager,
                               ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);

            // Pobierz kursy przypisane do tego wykładowcy
            var courses = await _context.Courses
                .Include(c => c.CourseRegistrations)
                .Where(c => c.LecturerId == userId)
                .ToListAsync();

            // Przekaż dane do widoku
            return View(new LecturerDashboardViewModel
            {
                Courses = courses,
                // Dodatkowe dane, takie jak oczekujące zgłoszenia, mogą być tutaj przekazane
            });
        }

        // GET: Lecturer/GradeInput?courseId=1
        public async Task<IActionResult> GradeInput(int courseId)
        {
            // Pobierz ID bieżącego wykładowcy
            var lecturerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Pobierz kurs i upewnij się, że jest przypisany do bieżącego wykładowcy
            var course = await _context.Courses
                .Include(c => c.CourseRegistrations)
                .ThenInclude(cr => cr.Student)
                .FirstOrDefaultAsync(c => c.CourseId == courseId && c.LecturerId == lecturerId);

            if (course == null)
            {
                return NotFound("Kurs nie znaleziony lub nie przypisany do ciebie.");
            }

            // Przygotuj ViewModel
            var model = new GradeInputViewModel
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                Students = course.CourseRegistrations.Select(cr => new StudentGradeInput
                {
                    StudentId = cr.StudentId,
                    //StudentName = cr.Student?.FirstName,
                    StudentName = cr.Student != null ? cr.Student.FirstName + " " + cr.Student.LastName : null,
                    Grade = _context.Grades
                                .Where(g => g.CourseId == course.CourseId && g.StudentId == cr.StudentId)
                                .Select(g => g.Score)
                                .FirstOrDefault()
                }).ToList()
            };

            return View(model);
        }

        // POST: Lecturer/SaveGrades
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveGrades(GradeInputViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var student in model.Students)
                {
                    // Sprawdź, czy ocena już istnieje
                    var existingGrade = await _context.Grades
                        .FirstOrDefaultAsync(g => g.CourseId == model.CourseId && g.StudentId == student.StudentId);

                    if (existingGrade == null)
                    {
                        // Utwórz nowy wpis oceny
                        var grade = new Grade
                        {
                            CourseId = model.CourseId,
                            StudentId = student.StudentId,
                            Score = Convert.ToInt32(student.Grade), // Domyślnie 0, jeśli null
                        };
                        _context.Grades.Add(grade);
                    }
                    else
                    {
                        // Zaktualizuj istniejącą ocenę
                        existingGrade.Score = Convert.ToInt32(student.Grade);
                        _context.Grades.Update(existingGrade);
                    }
                }

                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Oceny zostały pomyślnie zaktualizowane.";
                return RedirectToAction("Index"); // Przekieruj do listy kursów wykładowcy
            }

            // Jeśli ModelState jest niepoprawny, załaduj widok GradeInput z istniejącymi danymi
            var course = await _context.Courses
                .Include(c => c.CourseRegistrations)
                .ThenInclude(cr => cr.Student)
                .FirstOrDefaultAsync(c => c.CourseId == model.CourseId);

            if (course == null)
            {
                return NotFound("Kurs nie znaleziony.");
            }

            model.CourseName = course.CourseName;
            model.Students = course.CourseRegistrations.Select(cr => new StudentGradeInput
            {
                StudentId = cr.StudentId,
                StudentName = cr.Student.FirstName,
                Grade = _context.Grades
                            .Where(g => g.CourseId == course.CourseId && g.StudentId == cr.StudentId)
                            .Select(g => g.Score)
                            .FirstOrDefault()
            }).ToList();

            return View("GradeInput", model);
        }

        // GET: Lecturer/Courses
        public async Task<IActionResult> Courses()
        {
            var lecturerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var courses = await _context.Courses
                .Where(c => c.LecturerId == lecturerId)
                .ToListAsync();

            return View(courses);
        }
    }
}
