using DeansOfficeManagement.Data;
using DeansOfficeManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;





var builder = WebApplication.CreateBuilder(args);




// Dodaj us�ugi do kontenera.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? throw new InvalidOperationException("Nie znaleziono �a�cucha po��czenia 'DefaultConnection'.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Rejestracja Identity i konfiguracja ApplicationUser jako modelu u�ytkownika
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Dodaj wsparcie dla stron Razor
builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Konfiguracja potoku ��da� HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Dodaj middleware do uwierzytelniania
app.UseAuthentication();  // Upewnij si�, �e jest przed UseAuthorization

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();


