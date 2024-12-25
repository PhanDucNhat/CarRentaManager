using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project_CarRental.Component
{
    [ViewComponent(Name = "Product")]
    public class ProductComponent : ViewComponent
    {
        private DataContext _context;
        public ProductComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofProduct = (from m in _context.Products
                                 join n in _context.ProductDetails
                                 on m.ProductID equals n.ProductID
                                 where (m.IsActive == true)
                                 select new
                                 {
                                     m.ProductID,
                                     n.Images,
                                     m.CarName,
                                     n.PricesDay,
                                     n.Seats
                                 }).Take(6).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofProduct));
        }
    }
}
