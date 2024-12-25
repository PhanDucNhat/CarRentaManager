using Project_CarRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project_CarRental.Component
{
    [ViewComponent(Name = "ViewProduct")]
    public class ViewProductComponent : ViewComponent
    {
        private DataContext _context;
        public ViewProductComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofViewProduct = (from m in _context.ViewProducts
                                     where (m.IsActive == true)
                                     orderby Guid.NewGuid()
                                     select m).Take(6).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofViewProduct));
        }
    }
}
