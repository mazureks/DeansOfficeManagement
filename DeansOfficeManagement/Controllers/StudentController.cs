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
    [Authorize(Roles = "STUDENT")]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        //public IActionResult Index()
        public async Task<IActionResult> Index()
        {
            // Przekaż imię użytkownika do widoku za pomocą ViewBag
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                ViewBag.FirstName = user.FirstName; // Przekazanie imienia do widoku
            }


            return View();
        }

        // GET: Wyświetl dostępne kursy
        public async Task<IActionResult> RegisterCourse()
        {
            var availableCourses = await _context.Courses
                .Include(c => c.Lecturer)
                .ToListAsync();

            return View(availableCourses);
        }

        // POST: Zarejestruj się na kurs
        [HttpPost]
        public async Task<IActionResult> RegisterCourse(int courseId)
        {
            var userId = User.Identity.Name;
            var student = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userId);

            if (student == null)
            {
                return NotFound("Nie znaleziono studenta");
            }

            var course = await _context.Courses.FindAsync(courseId);
            if (course == null)
            {
                return NotFound("Nie znaleziono kursu");
            }

            // Sprawdź, czy student jest już zapisany na ten kurs
            var existingRegistration = await _context.CourseRegistrations
                .FirstOrDefaultAsync(cr => cr.CourseId == courseId && cr.StudentId == student.Id);

            if (existingRegistration != null)
            {
                ModelState.AddModelError("", "Jesteś już zapisany na ten kurs.");
                TempData["ErrorMessage"] = "Jesteś już zapisany na ten kurs.";

                return RedirectToAction(nameof(RegisterCourse));
            }

            // Zarejestruj studenta na kurs
            var courseRegistration = new CourseRegistration
            {
                StudentId = student.Id,
                CourseId = courseId,
                Status = "W toku"
            };

            _context.CourseRegistrations.Add(courseRegistration);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Pomyślnie zapisano na kurs.";
            return RedirectToAction(nameof(RegisterCourse));
        }

        public async Task<IActionResult> GradeOverview()
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Pobierz oceny dla zalogowanego studenta
            var grades = await _context.Grades
                .Where(g => g.Student.Id == studentId)
                .Select(g => new StudentGradeViewModel
                {
                    CourseName = g.Course.CourseName,
                    GradeValue = g.Score,
                })
                .ToListAsync();

            return View(grades);
        }

        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound("Nie znaleziono użytkownika.");
            }

            return View(user);
        }

        // GET: Wyświetl formularz zgłaszania wniosku
        public IActionResult SubmitRequest()
        {
            return View(new SubmitRequestViewModel());
        }

        // POST: Obsługa zgłaszania wniosku
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitRequest(SubmitRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = await _userManager.GetUserAsync(User);

                var newRequest = new Request
                {
                    RequestType = model.RequestType,
                    Description = model.Description,
                    DateSubmitted = DateTime.Now,
                    Status = "Oczekuje",
                    StudentId = student.Id
                };

                _context.Requests.Add(newRequest);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Twój wniosek został pomyślnie zgłoszony!";
                return RedirectToAction("ViewRequests");
            }

            return View(model);
        }

        // GET: Wyświetl wszystkie zgłoszone wnioski zalogowanego studenta
        public async Task<IActionResult> ViewRequests()
        {
            var user = await _userManager.GetUserAsync(User);
            var requests = _context.Requests
                                    .Where(r => r.StudentId == user.Id)
                                    .OrderByDescending(r => r.DateSubmitted)
                                    .ToList();

            return View(requests);
        }
    }
}
