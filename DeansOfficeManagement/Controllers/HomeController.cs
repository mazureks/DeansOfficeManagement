using DeansOfficeManagement.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using DeansOfficeManagement.Models;

namespace DeansOfficeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Sprawdü, czy uøytkownik jest zalogowany
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    // Przekaø imiÍ uøytkownika do widoku za pomocπ ViewBag
                    ViewBag.FirstName = user.FirstName;

                    // Przekieruj na podstawie roli uøytkownika
                    if (await _userManager.IsInRoleAsync(user, "Student"))
                    {
                        return RedirectToAction("Index", "Student");
                    }
                    else if (await _userManager.IsInRoleAsync(user, "Lecturer"))
                    {
                        return RedirectToAction("Index", "Lecturer");
                    }
                    else if (await _userManager.IsInRoleAsync(user, "Admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                }
            }

            // Jeúli uøytkownik nie jest zalogowany, przejdü do domyúlnego widoku strony g≥Ûwnej
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
