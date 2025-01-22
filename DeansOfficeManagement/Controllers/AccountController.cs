using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DeansOfficeManagement.Models;
using DeansOfficeManagement.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace DeansOfficeManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                    // Wyklucz przypisywanie ról podczas początkowej rejestracji użytkowników poza pierwszym
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Sprawdź, czy to pierwszy zarejestrowany użytkownik
                    int userCount = _userManager.Users.Count();

                    if (userCount == 1)
                    {
                        // Przypisz rolę "Admin" pierwszemu użytkownikowi
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        // Inni użytkownicy są rejestrowani bez ról
                        // Dziekan przypisze im role później
                    }

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        // Pobierz użytkownika na podstawie adresu e-mail
                        var user = await _userManager.FindByEmailAsync(model.Email);
                        if (user != null)
                        {
                            // Sprawdź, czy użytkownik jest Adminem
                            var roles = await _userManager.GetRolesAsync(user);
                            if (roles.Contains("ADMIN"))
                                return RedirectToAction("Index", "Admin");
                            else if (roles.Contains("STUDENT"))
                                return RedirectToAction("Index", "Student");
                            else if (roles.Contains("LECTURER"))
                                return RedirectToAction("Index", "Lecturer");
                        }

                        // Jeśli nie jest Adminem, przekieruj na stronę główną
                        return RedirectToAction("Index", "Home");
                    }
                    else if (result.IsLockedOut)
                    {
                        ModelState.AddModelError(string.Empty, "Konto zostało zablokowane.");
                    }
                    else if (result.IsNotAllowed)
                    {
                        ModelState.AddModelError(string.Empty, "E-mail nie został potwierdzony.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Nieprawidłowa próba logowania.");
                    }
                }

                return View(model);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize] // Tylko zalogowani użytkownicy mogą zmieniać hasło
        public IActionResult ChangePassword()
        {
            return View();
        }

        // Obsługa zmiany hasła
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Hasło zostało zmienione pomyślnie.";
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }


    }
}