using LAB5.Data;
using LAB5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace LAB5.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string firstName, string lastName, string password, string role)
        {
            if (ModelState.IsValid)  // Sprawdzamy czy model jest poprawny
            {
                var user = new User
                {
                    UserName = email,  // Użyjemy email jako nazwy użytkownika
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    Role = role,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)  // Hashowanie hasła
                };

                _context.Users.Add(user);  // Dodajemy użytkownika do bazy
                await _context.SaveChangesAsync();  // Zapisujemy zmiany w bazie danych

                return RedirectToAction("Login", "Account");  // Przekierowanie do strony logowania
            }
            return View();
        }
    }
}
