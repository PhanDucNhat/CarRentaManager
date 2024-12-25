using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project_CarRental.Component
{
    [ViewComponent(Name = "PageFourSeats")]
    public class PageFourSeatsComponent : ViewComponent
    {
        private DataContext _context;
        public PageFourSeatsComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofFourSeat = (from m in _context.ViewProducts
                                  where (m.IsActive == true) && (m.Seats == 4)
                                  orderby m.ProductID descending
                                  select m).Take(4).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofFourSeat));
        }
    }
}
