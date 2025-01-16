using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project_CarRental.Component
{
    [ViewComponent(Name = "Rental")]
    public class RentalComponent : ViewComponent
    {
        private DataContext _context;
        public RentalComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofRental = (from m in _context.Products
                                join n in _context.Rentals
                                on m.ProductID equals n.ProductID
                                join k in _context.Users
                                on n.UserID equals k.UserID
                                where (m.IsActive == true)
                                 select new
                                 {
                                     n.RentalID,
                                     n.UserID,
                                     m.ProductID,
                                     n.PickUpLocation,
                                     n.DropOffLocation,
                                     n.PickUpDate,
                                     n.DropOffDate,
                                     n.PickUpTime,
                                     n.IsActive,
                                     n.Status,
                                     m.CarName,
                                     k.Username
                                 }).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofRental));
        }
    }
}
