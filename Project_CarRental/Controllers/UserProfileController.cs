using Microsoft.AspNetCore.Mvc;
using Project_CarRental.Models;
using Project_CarRental.Utilities;

namespace Project_CarRental.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly DataContext _context;
        public UserProfileController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
