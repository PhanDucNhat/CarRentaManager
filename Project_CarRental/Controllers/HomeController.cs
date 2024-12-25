using Microsoft.AspNetCore.Mvc;
using Project_CarRental.Models;
using Project_CarRental.Utilities;
using System.Diagnostics;

namespace Project_CarRental.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

		[Route("/post-{slug}-{id:long}.html", Name = "Details")]

		public IActionResult DetailsPost(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var post = _context.Posts.FirstOrDefault(m => (m.PostID == id) && (m.IsActive == true));
			if (post == null)
			{
				return NotFound();
			}
			return View(post);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[Route("/list-{slug}-{id:int}.html", Name = "List")]
		public IActionResult List(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var list = _context.ViewProducts.Where(m => (m.ProductID == id) && (m.IsActive == true)).Take(6).ToList();

			if (list == null)
			{
				return NotFound();
			}
			return View(list);
		}

		[Route("/product-{slug}-{id:long}.html", Name = "DetailsProduct")]

		public IActionResult DetailsProduct(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var product = _context.ViewProducts.FirstOrDefault(m => (m.ProductID == id) && (m.IsActive == true));
			if (product == null)
			{
				return NotFound();
			}
			return View(product);
		}

		[Route("/booknow-{slug}-{id:long}.html", Name = "DetailsBookNow")]

		public IActionResult DetailsBookNow(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var product = _context.ViewProducts.FirstOrDefault(m => (m.ProductID == id) && (m.IsActive == true));
			if (product == null)
			{
				return NotFound();
			}
			return View(product);
		}

        public IActionResult Logout()
        {
            Functions._UserID = 0;
            Functions._Username = string.Empty;
            Functions._Email = string.Empty;
            Functions._Message = string.Empty;
            Functions._MessageEmail = string.Empty;

            return RedirectToAction("Index", "Home");
        }
    }
}
