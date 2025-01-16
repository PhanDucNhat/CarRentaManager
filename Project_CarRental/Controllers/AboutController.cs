using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using SelectPdf;

namespace Project_CarRental.Controllers
{
    public class AboutController : Controller
    {
        private readonly DataContext _context;
        public AboutController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
