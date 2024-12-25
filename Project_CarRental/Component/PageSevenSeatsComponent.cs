using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project_CarRental.Component
{
    [ViewComponent(Name = "PageSevenSeats")]
    public class PageSevenSeatsComponent : ViewComponent
    {
        private readonly DataContext _context;

        public PageSevenSeatsComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofSevenSeat = (from m in _context.ViewProducts
                                   where m.IsActive == true && m.Seats == 7
                                   orderby m.ProductID descending
                                   select m).Take(4).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofSevenSeat));
        }
    }
}
