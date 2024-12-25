using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace Project_CarRental.Controllers
{
	public class ServiceController : Controller
	{
		private readonly DataContext _context;
		public ServiceController(DataContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
