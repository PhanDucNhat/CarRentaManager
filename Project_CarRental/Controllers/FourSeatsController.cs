using Project_CarRental.Models;
using Project_CarRental.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;

namespace Project_CarRental.Controllers
{
    public class FourSeatsController : Controller
    {
        private readonly DataContext _context;
        public FourSeatsController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        /*public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Rental rental)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rental);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }*/
    }
}
