using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace Project_CarRental.Controllers
{
    public class SevenSeatsController : Controller
    {
        private readonly DataContext _context;
        public SevenSeatsController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
