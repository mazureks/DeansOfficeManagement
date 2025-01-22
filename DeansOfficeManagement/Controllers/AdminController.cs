using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeansOfficeManagement.Models;
using DeansOfficeManagement.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using DeansOfficeManagement.Models.ViewModels;

namespace DeansOfficeManagement.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public AdminController(UserManager<ApplicationUser> userManager,
                               RoleManager<IdentityRole> roleManager,
                               ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        // 1. Dodawanie i edycja studentów

        // Wyświetl wszystkich studentów
        public async Task<IActionResult> Students()
        {
            /*
             * var students = await _userManager.Users
                            .Where(u => u.Role == "Student")
                            .ToListAsync(); */

            // Pobierz użytkowników przypisanych do roli "STUDENT"
            var students = await _userManager.GetUsersInRoleAsync("STUDENT");

            // Przekaż listę użytkowników do widoku
            return View(students);
        }

        // Formularz do dodania nowego studenta
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        // Obsługa dodania nowego studenta
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStudent(ApplicationUser student, string password)
        {
            if (ModelState.IsValid)
            {
                student.UserName = student.Email;
                student.LockoutEnabled = false;
                student.Role = "Student";
                var result = await _userManager.CreateAsync(student, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(student, "Student");
                    return RedirectToAction("Students");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(student);
        }

        // Formularz do edycji istniejącego studenta
        [HttpGet]
        public async Task<IActionResult> EditStudent(string id)
        {
            var student = await _userManager.FindByIdAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        // Obsługa edycji istniejącego studenta
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditStudent(ApplicationUser student)
        {
            var existingStudent = await _userManager.FindByIdAsync(student.Id);
            if (existingStudent == null) return NotFound();

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.Email = student.Email;
            existingStudent.StudentNumber = student.StudentNumber;

            var result = await _userManager.UpdateAsync(existingStudent);
            if (result.Succeeded)
            {
                return RedirectToAction("Students");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(student);
        }

        // 2. Tworzenie kursów i przypisywanie wykładowców
        public async Task<IActionResult> Courses()
        {
            var courses = await _context.Courses.Include(c => c.Lecturer).ToListAsync();
            return View(courses);
        }

        // Formularz do tworzenia nowego kursu
        [HttpGet]
        public IActionResult CreateCourse()
        {
            var lecturers = (from user in _context.Users
                             join userRole in _context.UserRoles on user.Id equals userRole.UserId
                             join role in _context.Roles on userRole.RoleId equals role.Id
                             where role.Name == "Lecturer"
                             select new SelectListItem
                             {
                                 Value = user.Id,
                                 Text = user.FirstName + " " + user.LastName
                             }).ToList();

            ViewBag.Lecturers = lecturers;
            return View();
        }

        // Obsługa tworzenia nowego kursu i przypisywania wykładowców
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCourse(Course course, string lecturerId)
        {
            if (ModelState.IsValid)
            {
                var lecturer = await _userManager.FindByIdAsync(lecturerId);
                if (lecturer != null)
                {
                    course.LecturerId = lecturerId;
                    _context.Courses.Add(course);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Courses");
                }
                ModelState.AddModelError("", "Wybrany użytkownik nie jest wykładowcą.");
            }
            var lecturers = (from user in _context.Users
                             join userRole in _context.UserRoles on user.Id equals userRole.UserId
                             join role in _context.Roles on userRole.RoleId equals role.Id
                             where role.Name == "Lecturer"
                             select user).ToList();

            ViewBag.Lecturers = lecturers;
            return View(course);
        }
        public async Task<IActionResult> EditCourse(int id)
        {
            // Znajdź kurs w bazie danych
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();

            // Pobierz listę wykładowców i skonwertuj na SelectListItem
            var lecturers = (from user in _context.Users
                             join userRole in _context.UserRoles on user.Id equals userRole.UserId
                             join role in _context.Roles on userRole.RoleId equals role.Id
                             where role.Name == "Lecturer"
                             select new SelectListItem
                             {
                                 Value = user.Id,
                                 Text = user.FirstName + " " + user.LastName
                             }).ToList();

            // Przypisz listę do ViewBag.Lecturers
            ViewBag.Lecturers = lecturers;

            return View(course);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                // Aktualizuj kurs w bazie danych
                _context.Update(course);
                await _context.SaveChangesAsync();
                return RedirectToAction("Courses");
            }

            // Jeśli walidacja się nie powiedzie, załaduj ponownie listę wykładowców
            var lecturers = (from user in _context.Users
                             join userRole in _context.UserRoles on user.Id equals userRole.UserId
                             join role in _context.Roles on userRole.RoleId equals role.Id
                             where role.Name == "Lecturer"
                             select new SelectListItem
                             {
                                 Value = user.Id,
                                 Text = user.FirstName + " " + user.LastName
                             }).ToList();

            ViewBag.Lecturers = lecturers;

            return View(course);
        }

        // 3. Zarządzanie rejestracjami kursów studentów

        // Wyświetl wszystkie rejestracje kursów
        public async Task<IActionResult> CourseRegistrations()
        {
            var registrations = await _context.CourseRegistrations
                .Include(r => r.Course)
                .Include(r => r.Student)
                .ToListAsync();
            return View(registrations);
        }

        // Zatwierdź lub odrzuć rejestrację kursu
        [HttpPost]
        public async Task<IActionResult> UpdateRegistrationStatus(int registrationId, int courseId, string studentId, string status)
        {
            var registration = _context.CourseRegistrations
                                .FirstOrDefault(r => r.StudentId == studentId && r.CourseId == courseId);

            if (registration == null) return NotFound();

            registration.Status = status;
            _context.CourseRegistrations.Update(registration);
            await _context.SaveChangesAsync();
            return RedirectToAction("CourseRegistrations");
        }

        // 4. Przeglądaj i oceniaj wnioski studentów

        // Wyświetl wszystkie wnioski studentów
        public async Task<IActionResult> Requests()
        {
            var requests = await _context.Requests.Include(r => r.Student).ToListAsync();
            return View(requests);
        }

        // Zatwierdź lub odrzuć wniosek studenta
        [HttpPost]
        public async Task<IActionResult> UpdateRequestStatus(int requestId, string status)
        {
            var request = await _context.Requests.FindAsync(requestId);
            if (request == null) return NotFound();

            request.Status = status;
            _context.Requests.Update(request);
            await _context.SaveChangesAsync();
            return RedirectToAction("Requests");
        }

        public async Task<IActionResult> AssignRoles()
        {
            var users = await _userManager.Users
                .Select(u => new UserViewModel
                {
                    Id = u.Id,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName
                })
                .ToListAsync();

            var availableRoles = await _roleManager.Roles
                .Select(r => r.Name)
                .ToListAsync();

            var model = new AssignRolesViewModel
            {
                Users = users,
                AvailableRoles = availableRoles
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRoles(AssignRolesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    var currentRoles = await _userManager.GetRolesAsync(user);
                    var result = await _userManager.RemoveFromRolesAsync(user, currentRoles);

                    if (result.Succeeded)
                    {
                        result = await _userManager.AddToRolesAsync(user, model.SelectedRoles);
                        if (result.Succeeded)
                        {
                            TempData["SuccessMessage"] = "Role zostały pomyślnie przypisane użytkownikowi.";
                            return RedirectToAction("AssignRoles");
                        }
                    }
                }
            }

            // Jeśli ModelState jest niepoprawny, przeładuj dostępne role i użytkowników do ponownego renderowania widoku
            model.Users = await _userManager.Users
                .Select(u => new UserViewModel { Id = u.Id, Email = u.Email })
                .ToListAsync();

            model.AvailableRoles = await _roleManager.Roles
                .Select(r => r.Name)
                .ToListAsync();

            // Jeśli coś się nie uda, dodaj wiadomość o błędzie
            TempData["ErrorMessage"] = "Wystąpił błąd podczas przypisywania ról. Spróbuj ponownie.";
            return View(model);
        }

        public async Task<IActionResult> Statistics()
        {
            // Statystyki studentów
            var topStudents = await _context.Users
                .Where(u => u.Role == "STUDENT")
                .Select(u => new StudentData
                {
                    StudentName = u.FirstName + " " + u.LastName,
                    WeightedAverage = _context.Grades
                        .Where(g => g.StudentId == u.Id)
                        .Sum(g => g.Score * g.Course.Credits) /
                        (_context.Grades
                            .Where(g => g.StudentId == u.Id)
                            .Sum(g => g.Course.Credits) + 0.0001),
                    CourseCount = _context.Grades
                        .Where(g => g.StudentId == u.Id)
                        .Count()
                })
                .OrderByDescending(s => s.WeightedAverage)
                .Take(3)
                .ToListAsync();

            // Statystyki wykładowców
            var lecturerStats = await _context.Courses
                .GroupBy(c => c.Lecturer)
                .Select(g => new LecturerData
                {
                    LecturerName = g.Key.FirstName + " " + g.Key.LastName,
                    CourseCount = g.Count(),
                    TotalCredits = g.Sum(c => c.Credits)
                })
                .ToListAsync();

            // Wypełnienie modelu
            var model = new StatisticsViewModel
            {
                TopStudents = topStudents,
                LecturerStatistics = lecturerStats
            };

            return View(model);
        }










    }
}
