using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mashup.Models;

namespace Mashup.Controllers;

public class DashboardController : Controller
{
	private readonly AppDbContext _context;

	public DashboardController(AppDbContext context)
	{
		_context = context;
	}

	public IActionResult Dashboard()
    {
        return View();
    }
}