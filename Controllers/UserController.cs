
using Microsoft.AspNetCore.Mvc;
using Mashup.Models;

namespace Mashup.Controllers
{
	public class UserController : Controller
	{
		private readonly AppDbContext _context;

		public UserController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(string username, string password)
		{
			var user = _context.Users.FirstOrDefault(u => u.Username == username);
			if(user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
			{
				return RedirectToAction("Dashboard", "Home");
			}
			else
			{
				ViewBag.ErrorMessage = "Invalid username or password.";
				return View();
			}
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Register(string username, string password, string city)
		{
			if(_context.Users.Any(u => u.Username == username))
			{
				ViewBag.ErrorMessage = "Username already exists.";
				return View();
			}

			var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
			var user = new UserModel
			{
				Username = username,
				PasswordHash = passwordHash,
				City = city
			};

			_context.Users.Add(user);
			_context.SaveChanges();

			return RedirectToAction("Login");
		}
	}
}

