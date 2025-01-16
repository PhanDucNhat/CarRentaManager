using Microsoft.AspNetCore.Mvc;
using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_CarRental.Utilities;

namespace Project_CarRental.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompleteController : Controller
    {
        private readonly DataContext _context;

        public CompleteController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            var mnList = (from r in _context.Rentals
                          join p in _context.Products
                          on r.ProductID equals p.ProductID
                          join u in _context.Users
                          on r.UserID equals u.UserID
                          where r.Status == "Hoàn thành"
                          select new Rental
                          {
                              RentalID = r.RentalID,
                              UserID = r.UserID,
                              ProductID = r.ProductID,
                              PickUpLocation = r.PickUpLocation,
                              DropOffLocation = r.DropOffLocation,
                              PickUpDate = r.PickUpDate,
                              DropOffDate = r.DropOffDate,
                              PickUpTime = r.PickUpTime,
                              IsActive = r.IsActive,
                              Status = r.Status,
                              CarName = p.CarName,
                              FullName = u.FullName,
                              Phone = u.Phone
                          }).OrderBy(m => m.RentalID).ToList();

            return View(mnList);
        }
    }
}
