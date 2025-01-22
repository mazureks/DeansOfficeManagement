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
            // Sprawd�, czy u�ytkownik jest zalogowany
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    // Przeka� imi� u�ytkownika do widoku za pomoc� ViewBag
                    ViewBag.FirstName = user.FirstName;

                    // Przekieruj na podstawie roli u�ytkownika
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

            // Je�li u�ytkownik nie jest zalogowany, przejd� do domy�lnego widoku strony g��wnej
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
